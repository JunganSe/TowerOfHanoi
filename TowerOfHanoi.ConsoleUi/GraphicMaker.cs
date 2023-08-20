namespace TowerOfHanoi.ConsoleUi;

public class GraphicMaker
{
    private readonly string[] _towerPieces;
    private readonly int _maxTowerHeight;

    public GraphicMaker(int maxTowerHeight)
    {
        _towerPieces = CreatePieces();
        _maxTowerHeight = maxTowerHeight;
    }

    private string[] CreatePieces()
    {
        // TODO: Ta hänsyn till _maxTowerHeight
        return new string[]
            {
                "      ==      ",
                "     ====     ",
                "    ======    ",
                "   ========   ",
                "  ==========  ",
                " ============ ",
                "==============",
            };
    }



    internal string GetTowerPiece(int size)
    {
        return _towerPieces[size - 1];
    }

    internal string GetTowerFoundation()
    {
        // TODO: Ta hänsyn till _maxTowerHeight
        return "~~~~~~~~~~~~~~~~~~";
    }

    internal string GetPaddedTowerName(string name)
    {
        // TODO: Ta hänsyn till _maxTowerHeight
        // TODO: Padda i mitten
        return name.PadRight(18);
    }
}
