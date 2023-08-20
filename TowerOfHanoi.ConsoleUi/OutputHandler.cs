using System.Drawing;
using TowerOfHanoi.Core.Components;
using TowerOfHanoi.Core.Extensions;

namespace TowerOfHanoi.ConsoleUi;

internal class OutputHandler
{
    private readonly Rectangle _playField;
    private readonly Rectangle _messageBox;
    private readonly string[] _towerPieces;

    public OutputHandler()
    {
        _playField = new Rectangle(2, 1, 62, 12);
        _messageBox = new Rectangle(2, 13, 62, 4);
        _towerPieces = new string[]
            {
                "      ==      ",
                "     ====     ",
                "    ======    ",
                "   ========   ",
                "  ==========  ",
                " ============ ",
                "==============",
            };
    }

    public void ClearScreen()
    {
        Console.Clear();
    }

    public void DrawBorders()
    {
        DrawBox(_playField.X, _playField.Y, _playField.Width, _playField.Height);
        DrawBox(_messageBox.X, _messageBox.Y, _messageBox.Width, _messageBox.Height);
    }

    public void DrawTowers(Towers towers)
    {
        int x = _playField.X + 2;
        int y = _playField.Y + 9;

        Console.SetCursorPosition(x, y);
        Console.Write("~~~~~~~~~~~~~~~~~~  ~~~~~~~~~~~~~~~~~~  ~~~~~~~~~~~~~~~~~~");
        Console.SetCursorPosition(x, y + 1);
        Console.Write("        1                   2                   3         ");
        DrawTower(towers.Left, x, y);
        DrawTower(towers.Middle, x + 20, y);
        DrawTower(towers.Right, x + 40, y);
    }

    public void DrawMessages(Messages messages)
    {
        int x = _messageBox.X + 1;
        int y = _messageBox.Y + 1;
        int maxWidth = _messageBox.Width - 2;

        string status = messages.Status.Truncate(maxWidth).PadRight(maxWidth);
        Console.SetCursorPosition(x, y);
        Console.Write(status);

        string instruction = messages.Instruction.Truncate(maxWidth).PadRight(maxWidth);
        Console.SetCursorPosition(x, y + 1);
        Console.Write(instruction);
    }



    private void DrawBox(int x, int y, int width, int height)
    {
        string parts = "─│┌┐└┘";
        string horizontalLine = new String(parts[0], width - 2);

        Console.SetCursorPosition(x, y);
        Console.Write(parts[2] + horizontalLine + parts[3]);

        for (int i = 1; i < height - 1; i++)
        {
            Console.SetCursorPosition(x, y + i);
            Console.Write(parts[1]);
            Console.SetCursorPosition(x + width - 1, y + i);
            Console.Write(parts[1]);
        }

        Console.SetCursorPosition(x, y + height - 1);
        Console.Write(parts[4] + horizontalLine + parts[5]);
    }

    private void DrawTower(Tower tower, int x, int y)
    {
        for (int i = 0; i < tower.Count; i++)
        {
            int size = tower.Reverse().ElementAt(i).Size;
            Console.SetCursorPosition(x + 2, y - 1 - i);
            Console.Write(_towerPieces[size - 1]);
        }
    }
}
