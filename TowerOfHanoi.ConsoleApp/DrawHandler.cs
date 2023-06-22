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
        // Passa in i nedre rutan.
    }
}
