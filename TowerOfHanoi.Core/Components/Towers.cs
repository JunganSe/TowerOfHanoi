namespace TowerOfHanoi.Core.Components;

public class Towers
{
    private readonly List<Tower> _towers;

    public Tower Left => _towers[0];
    public Tower Middle => _towers[1];
    public Tower Right => _towers[2];

    public Towers()
    {
        _towers = new List<Tower>() { new(), new(), new() };
    }

    public void Initialize(int height)
    {
        Left.Clear();
        Middle.Clear();
        Right.Clear();
        for (int size = height; size > 0; size--)
            Left.Push(new TowerPiece(size));
    }
}
