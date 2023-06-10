using TowerOfHanoi.Core.Enums;
using TowerOfHanoi.Core.Interfaces;

namespace TowerOfHanoi.ConsoleApp;

public class IOHandler : IIOHandler
{
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
            ConsoleKey.NumPad1 => InputCommand.Stack1,
            ConsoleKey.NumPad2 => InputCommand.Stack2,
            ConsoleKey.NumPad3 => InputCommand.Stack3,
            ConsoleKey.R => InputCommand.Restart,
            ConsoleKey.Q => InputCommand.Quit,
            _ => InputCommand.None
        };
    }
}
