using TowerOfHanoi.Core.Extensions;

namespace TowerOfHanoi.ConsoleUi;

internal class GraphicMaker
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
        _towerPieces = CreateTowerPieces();
    }

    private string[] CreateTowerPieces() 
        => Enumerable.Range(1, _maxTowerHeight)
            .Select(i => new string(_towerPiecePart, i * 2).PadBoth(_maxTowerHeight * 2))
            .ToArray();



    internal string GetTowerPiece(int size) 
        => _towerPieces[size - 1];

    internal string GetTowerFoundation() 
        => new string(_FoundationPart, _foundationWidth);

    internal string GetPaddedTowerName(string name) 
        => name.PadBoth(_foundationWidth);

    internal string GetBorderParts()
        => _borderParts;
}
