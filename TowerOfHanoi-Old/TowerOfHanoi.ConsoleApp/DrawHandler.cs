using TowerOfHanoi.Core.Extensions;
using TowerOfHanoi.Core.GameComponents;

namespace TowerOfHanoi.ConsoleApp;

public class DrawHandler
{
    public Rectangle PlayField { get; set; }
    public Rectangle MessageBox { get; set; }

    public DrawHandler(Rectangle playField, Rectangle messageBox)
    {
        PlayField = playField;
        MessageBox = messageBox;
    }

    public void DrawBorders()
    {
        DrawBox(PlayField.X, PlayField.Y, PlayField.Width, PlayField.Height);
        DrawBox(MessageBox.X, MessageBox.Y, MessageBox.Width, MessageBox.Height);
    }

    public void DrawTowers(Towers towers)
    {
        var floors = new string[]
        {
            "      ==      ",
            "     ====     ",
            "    ======    ",
            "   ========   ",
            "  ==========  ",
            " ============ ",
            "==============",
        };
        int x = PlayField.X + 2;
        int y = PlayField.Y + 9;

        Console.SetCursorPosition(x, y);
        Console.Write("~~~~~~~~~~~~~~~~~~  ~~~~~~~~~~~~~~~~~~  ~~~~~~~~~~~~~~~~~~");
        Console.SetCursorPosition(x, y + 1);
        Console.Write("       LEFT               MIDDLE               RIGHT      ");
        DrawTower(towers.Left, x, y);
        DrawTower(towers.Middle, x + 20, y);
        DrawTower(towers.Right, x + 40, y);

        void DrawTower(Tower tower, int x, int y)
        {
            for (int i = 0; i < tower.Count; i++)
            {
                int floorIndex = tower.Reverse().ElementAt(i).Size - 1;
                Console.SetCursorPosition(x + 2, y - 1 - i);
                Console.Write(floors[floorIndex]);
            }
        }
    }

    public void DrawMessages(Messages messages)
    {
        int x = MessageBox.X + 1;
        int y = PlayField.Y + MessageBox.Y + 1;
        int maxWidth = MessageBox.Width - 2;

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
}
