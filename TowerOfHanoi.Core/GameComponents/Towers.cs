namespace TowerOfHanoi.Core.GameComponents;

public class Towers
{
    public Stack<TowerPiece> Left { get; private set; } = new();
    public Stack<TowerPiece> Middle { get; private set; } = new();
    public Stack<TowerPiece> Right { get; private set; } = new();
}
