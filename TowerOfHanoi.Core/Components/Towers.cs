namespace TowerOfHanoi.Core.Components;

public class Towers
{
    private readonly List<Tower> _towers;

    public Tower Left => _towers[0];
    public Tower Middle => _towers[1];
    public Tower Right => _towers[2];

    public Towers()
    {
        _towers = new List<Tower>()
        {
            new() { Name = "left"},
            new() { Name = "middle"},
            new() { Name = "right"},
        };
    }

    public void Initialize(int height)
    {
        _towers.ForEach(t => t.Clear());
        for (int size = height; size > 0; size--)
            Left.Push(new TowerPiece(size));
    }

    public void ClearHighlights()
    {
        _towers.ForEach(t => t.Highlight = false);
    }
}
