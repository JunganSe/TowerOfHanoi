using TowerOfHanoi.Core.Components;
using TowerOfHanoi.Core.Enums;
using TowerOfHanoi.Core.Interfaces;

namespace TowerOfHanoi.ConsoleUi;

public class Ui : IUi
{
    private readonly InputHandler _inputHandler;
    private readonly OutputHandler _outputHandler;

    public Ui()
    {
        _inputHandler = new InputHandler();
        _outputHandler = new OutputHandler();
        Console.CursorVisible = false;
    }

    public void Initialize() // NOTE: Överflödig?
    {
        _outputHandler.ClearScreen();
    }

    public void Draw(World world)
    {
        _outputHandler.ClearScreen();
        _outputHandler.DrawBorders();
        _outputHandler.DrawTowers(world.Towers);
        _outputHandler.DrawMessages(world.Messages);
    }

    public InputCommand GetInputCommand() 
        => _inputHandler.GetInputCommand();

    public int GetDifficulty(Dictionary<int, string> difficulties)
    {
        // TODO: Välja svårighetsgrad.
        return 3;
    }
}
