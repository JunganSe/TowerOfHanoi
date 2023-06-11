using TowerOfHanoi.Core.Enums;
using TowerOfHanoi.Core.GameComponents;
using TowerOfHanoi.Core.Interfaces;

namespace TowerOfHanoi.Core;

public class Game
{
    private readonly IIOHandler _ioHandler;
    private bool _restart;
    private bool _keepLooping;
    private Tower? _targetTower = null;
    private GameState _state = GameState.None;

    public Towers Towers { get; set; } = new();
    public Messages Messages { get; private set; } = new();
    public int Difficulty { get; private set; }
    public int TowerHeight { get; set; }
    public int Moves { get; private set; }

    public Game(IIOHandler ioHandler)
    {
        _ioHandler = ioHandler;
        _restart = true;
        _keepLooping = true;
    }



    public void Run()
    {
        while (_restart)
        {
            _ioHandler.ClearScreen();
            SelectDifficulty();
            Initialize();
            while (_keepLooping)
            {
                MainLoop();
                CheckFinish();
            }
            Finish();
        }
        Quit();
    }

    private void SelectDifficulty()
    {
        string message = "Select Difficulty:\n" +
            "1. Child's play\n" +
            "2. Easy\n" +
            "3. Medium\n" +
            "4. Hard\n" +
            "5. Kinda tedious";
        _ioHandler.PrintMessage(message);
        while (true)
        {
            var input = _ioHandler.GetInputChar().ToString();
            if (int.TryParse(input, out int parsed)
                && (parsed is >= 1 and <= 5))
            {
                Difficulty = parsed;
                TowerHeight = parsed + 2;
                break;
            }
        }
    }

    private void Initialize()
    {
        _ioHandler.ClearScreen();
        Towers.Initialize(TowerHeight);
        Messages.Clear();
        Moves = 0;
        _keepLooping = true;
        _state = GameState.Take;
    }

    private void MainLoop()
    {
        // - Uppdatera meddelande.
        // - Ta input för att plocka upp våning. (Och restart/quit)
        // - Kontrollera att våning kan plockas upp.
        //   - Om inte, meddela och ta input igen.
        // - Markera vald våning.
        // - Uppdatera meddelande.
        // - Ta input för att lägga ner våning. (Och restart/quit)
        // - Kontrollera att våning kan läggas ner.
        //   - Om inte, meddela och lägg tillbaka våning. Börja om.
        // - Lägg ner våning.

        Messages.Instruction = "Select tower to take from.";
        // TODO: Uppdatera skärmen så meddelandet syns.
        var command = _ioHandler.GetInputCommand();
        if (HandleEscapeInput(command))
            return;
        if (HandleTakeInput(command))
        {

        }
        
    }

    private bool HandleEscapeInput(InputCommand command)
    {
        switch (command)
        {
            case InputCommand.Restart:
                _keepLooping = false;
                _restart = true;
                return true;
            case InputCommand.Quit:
                _keepLooping = false;
                _restart = false;
                return true;
            default:
                return false;
        }
    }

    private bool HandleTakeInput(InputCommand command)
    {
        return command switch
        {
            InputCommand.TowerLeft => TryTargetTower(Towers.Left),
            InputCommand.TowerMiddle => TryTargetTower(Towers.Middle),
            InputCommand.TowerRight => TryTargetTower(Towers.Right),
            _ => false
        };
    }

    private bool TryTargetTower(Tower tower)
    {
        if (tower.HasContent)
        {
            _targetTower = tower;
            return true;
        }
        _targetTower = null;
        return false;
    }

    private void CheckFinish()
    {
        // - Kolla om alla våningar är på högra sidan.
    }

    private void Finish()
    {
        // - Beräkna bästa möjliga poäng för svårighetsgraden.
        // - Meddela hur det gick.
        // - Fråga: Börja om eller avsluta.
    }

    private void Restart()
    {
        // - Börja om med att välja svårighetsgrad.
    }

    private void Quit()
    {
        // Stäng ner spelet genom att anropa metod i ui-appen?
    }
}
