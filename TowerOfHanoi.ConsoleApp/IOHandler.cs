using TowerOfHanoi.Core.Enums;
using TowerOfHanoi.Core.GameComponents;
using TowerOfHanoi.Core.Interfaces;

namespace TowerOfHanoi.ConsoleApp;

public class IOHandler : IIOHandler
{
    private readonly DrawHandler _drawHandler;

    public IOHandler(DrawHandler drawHandler)
    {
        _drawHandler = drawHandler;
    }



    public char GetInputChar()
    {
        return Console.ReadKey(true).KeyChar;
    }

    public InputCommand GetInputCommand()
    {
        var key = Console.ReadKey(true).Key;
        return MapConsoleKeyToInputCommand(key);
    }

    private InputCommand MapConsoleKeyToInputCommand(ConsoleKey key)
    {
        return key switch
        {
            ConsoleKey.A => InputCommand.TowerLeft,
            ConsoleKey.S => InputCommand.TowerMiddle,
            ConsoleKey.D => InputCommand.TowerRight,
            ConsoleKey.R => InputCommand.Restart,
            ConsoleKey.Q => InputCommand.Quit,
            _ => InputCommand.None
        };
    }



    public void ClearScreen()
    {
        Console.Clear();
    }

    public void Initialize()
    {
        ClearScreen();
        _drawHandler.DrawBorders();
    }

    public void DrawTowers(Towers towers)
    {
        _drawHandler.DrawTowers(towers);
    }

    public void DrawMessages(Messages messages)
    {
        _drawHandler.DrawMessages(messages);
    }

    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }
}
