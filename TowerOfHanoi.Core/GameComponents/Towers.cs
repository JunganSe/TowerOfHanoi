namespace TowerOfHanoi.Core.GameComponents;

public class Towers
{
    public Tower Left { get; private set; }
    public Tower Middle { get; private set; }
    public Tower Right { get; private set; }

    public Towers()
    {
        Left = new() { Name = "Left"};
        Middle = new() { Name = "Middle" };
        Right = new() { Name = "Right" };
    }

    public void Initialize(int height)
    {
        Left.Clear();
        Middle.Clear();
        Right.Clear();
        for (int size = height; size > 0; size--)
            Left.Push(new TowerPiece(size));
    }

    public void Highlight(Tower tower)
    {
        tower.Highlight = true;
    }

    public void ClearHighlights()
    {
        Left.Highlight = false;
        Middle.Highlight = false;
        Right.Highlight = false;
    }
}
