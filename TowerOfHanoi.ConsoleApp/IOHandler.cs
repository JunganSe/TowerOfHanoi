using TowerOfHanoi.Core.Enums;
using TowerOfHanoi.Core.Interfaces;

namespace TowerOfHanoi.ConsoleApp;

public class IOHandler : IIOHandler
{
    private readonly DrawHandler _drawHandler;

    public IOHandler(DrawHandler drawHandler)
    {
        _drawHandler = drawHandler;
    }

    public InputCommand GetInput()
    {
        var key = GetUserInput();
        return MapConsoleKeyToInputCommand(key);
    }

    private ConsoleKey GetUserInput()
    {
        ConsoleKey key = ConsoleKey.NoName;
        while (Console.KeyAvailable)
            key = Console.ReadKey(true).Key;
        return key;
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



    public void DrawScreen()
    {
        _drawHandler.DrawScreen();
    }
}
