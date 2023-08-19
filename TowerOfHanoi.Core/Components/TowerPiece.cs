namespace TowerOfHanoi.Core.Components;

public readonly struct TowerPiece
{
    public int Size { get; }

    public TowerPiece(int size)
    {
        Size = size;
    }
}

