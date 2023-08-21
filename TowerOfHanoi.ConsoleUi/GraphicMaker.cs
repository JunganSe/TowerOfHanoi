using TowerOfHanoi.Core.Extensions;

namespace TowerOfHanoi.ConsoleUi;

public class GraphicMaker
{
    private readonly int _maxTowerHeight;
    private readonly int _foundationWidth;
    private readonly string _borderParts;
    private readonly char _FoundationPart;
    private readonly char _towerPiecePart;
    private readonly string[] _towerPieces;

    public GraphicMaker(int maxTowerHeight)
    {
        _maxTowerHeight = maxTowerHeight;
        _foundationWidth = (maxTowerHeight + 2) * 2;
        _borderParts = "─│┌┐└┘";
        _FoundationPart = '~';
        _towerPiecePart = '=';
        _towerPieces = CreatePieces();
    }

    private string[] CreatePieces()
    {
        return Enumerable.Range(1, _maxTowerHeight)
            .Select(i => new string(_towerPiecePart, i * 2).PadBoth(_maxTowerHeight * 2))
            .ToArray();
    }



    internal string GetTowerPiece(int size)
    {
        return _towerPieces[size - 1];
    }

    internal string GetTowerFoundation()
    {
        return new string(_FoundationPart, _foundationWidth);
    }

    internal string GetPaddedTowerName(string name)
    {
        return name.PadBoth(_foundationWidth);
    }

    internal string GetBorderParts()
        => _borderParts;
}
