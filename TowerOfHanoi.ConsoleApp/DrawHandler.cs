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
        // Två rutor på höjden som sitter ihop.
    }

    public void DrawTowers(Towers towers)
    {
        // Mitt i övre rutan.
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
}
