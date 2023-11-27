using TowerOfHanoi.Core.Enums;

namespace TowerOfHanoi.ConsoleUi;

internal class InputHandler
{
    public int GetNumberInput(List<int> validNumbers)
    {
        while (true)
        {
            var key = Console.ReadKey(true).KeyChar.ToString();
            bool parseSucceeded = int.TryParse(key, out int parsedKey);
            if (parseSucceeded && validNumbers.Contains(parsedKey))
                return parsedKey;
        }
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
            ConsoleKey.NumPad1 => InputCommand.TowerLeft,
            ConsoleKey.NumPad2 => InputCommand.TowerMiddle,
            ConsoleKey.NumPad3 => InputCommand.TowerRight,
            ConsoleKey.R => InputCommand.Restart,
            ConsoleKey.Q => InputCommand.Quit,
            _ => InputCommand.None
        };
    }
}
