namespace TowerOfHanoi.Core.GameComponents;

public class Tower : Stack<TowerPiece>
{
    public string Name { get; init; } = "";
    public bool Highlight { get; set; } = false;
    public bool HasContent => this.Any();
}
