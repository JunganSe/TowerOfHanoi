namespace TowerOfHanoi.Core.Components;

public class Tower : Stack<TowerPiece>
{
    public bool IsEmpty => Count == 0;
}
