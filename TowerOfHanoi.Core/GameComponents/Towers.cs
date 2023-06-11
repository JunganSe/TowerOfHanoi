namespace TowerOfHanoi.Core.GameComponents;

public class Towers
{
    public Tower Left { get; private set; } = new();
    public Tower Middle { get; private set; } = new();
    public Tower Right { get; private set; } = new();

    public void ClearAll()
    {
        Left.Clear();
        Middle.Clear();
        Right.Clear();
    }

    public void Initialize(int height)
    {
        ClearAll();
        for (int size = height; size > 0; size--)
            Left.Push(new TowerPiece(size));
    }
}
