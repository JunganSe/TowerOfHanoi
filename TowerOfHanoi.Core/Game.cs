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

    private void Restart()
    {
        // - Börja om med att välja svårighetsgrad.
    }

    private void Quit()
    {
        // Stäng ner spelet genom att anropa metod i ui-appen?
    }
}
