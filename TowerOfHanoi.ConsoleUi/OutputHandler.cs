using System.Drawing;
using TowerOfHanoi.Core.Components;

namespace TowerOfHanoi.ConsoleUi;

internal class OutputHandler
{
    private readonly Rectangle _playField;
    private readonly Rectangle _messageBox;

    public OutputHandler()
    {
        _playField = new Rectangle(2, 1, 62, 12);
        _messageBox = new Rectangle(2, 13, 62, 4);
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
        throw new NotImplementedException();
    }

    public void DrawMessages(Messages messages)
    {
        throw new NotImplementedException();
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
}
