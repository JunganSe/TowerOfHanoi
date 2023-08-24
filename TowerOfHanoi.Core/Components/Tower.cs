namespace TowerOfHanoi.Core.Components;

public class Tower : Stack<TowerPiece>
{
    public string Name { get; set; } = "";
    public bool Highlight { get; set; } = false;
    public bool IsEmpty => Count == 0;
}
