namespace TowerOfHanoi.Core.GameComponents;

public class Tower
{
    private readonly Stack<TowerPiece> _pieces = new();

    public int Count => _pieces.Count;

    public void Clear()
        => _pieces.Clear();

    public void Push(TowerPiece piece)
        => _pieces.Push(piece);

    public TowerPiece Pop()
        => _pieces.Pop();

    public TowerPiece Peek()
        => _pieces.Peek();
}
