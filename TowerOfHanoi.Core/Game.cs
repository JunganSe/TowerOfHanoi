using TowerOfHanoi.Core.Enums;
using TowerOfHanoi.Core.GameComponents;
using TowerOfHanoi.Core.Interfaces;

namespace TowerOfHanoi.Core;

public partial class Game
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

    private void MainLoop()
    {
        // TODO: Uppdatera allt på skärmen.
        Messages.Clear();

        if (_state == GameState.Take)
        {
            Towers.ClearHighlights();
            Messages.Instruction = "Select tower to take from.";
            // TODO: Uppdatera visning av meddelande.

            var command = _ioHandler.GetInputCommand();
            if (HandleEscapeInput(command))
                return;
            _targetTower = MapCommandToTower(command);

            if (_targetTower == null)
            {
                Messages.Status = "Unknown command, try again.";
                return;
            }
            if (!_targetTower.HasContent)
            {
                Messages.Status = "Can not take from empty tower.";
                return;
            }

            Messages.Status = $"Taking from {_targetTower.Name} tower.";
            Towers.Highlight(_targetTower);
            _state = GameState.Place;
        }

        if (_state == GameState.Place)
        {
            // - Ta input för att lägga ner våning. (Och restart/quit)
            // - Kontrollera att våning kan läggas ner.
            //   - Om inte, meddela och släpp target. Börja om.
            // - Lägg ner våning.
        }
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
