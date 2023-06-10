namespace TowerOfHanoi.Core.GameComponents;

public class Towers
{
    public Stack<TowerPiece> Left { get; private set; } = new();
    public Stack<TowerPiece> Middle { get; private set; } = new();
    public Stack<TowerPiece> Right { get; private set; } = new();

    public void Clear()
    {
        Left.Clear();
        Middle.Clear();
        Right.Clear();
    }

    public void Initialize(int height)
    {
        Clear();
        for (int size = height; size > 0; size--)
            Left.Push(new TowerPiece(size));
    }
}
