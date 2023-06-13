namespace TowerOfHanoi.Core.GameComponents;

public class Tower
{
    private readonly Stack<TowerPiece> _pieces = new();

    public string Name { get; init; } = "";
    public bool Highlight { get; set; } = false;
    public int Count => _pieces.Count;
    public bool HasContent => _pieces.Any();

    public void Clear()
        => _pieces.Clear();

    public void Push(TowerPiece piece)
        => _pieces.Push(piece);

    public TowerPiece Pop()
        => _pieces.Pop();

    public TowerPiece Peek()
        => _pieces.Peek();
}
