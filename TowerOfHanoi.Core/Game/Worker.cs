using TowerOfHanoi.Core.Components;
using TowerOfHanoi.Core.Enums;
using TowerOfHanoi.Core.Interfaces;

namespace TowerOfHanoi.Core.Game;

internal class Worker
{
    private readonly IUi _ui;
    private readonly World _world;

    public Worker(IUi ui, World world)
    {
        _ui = ui;
        _world = world;
    }



    public int SelectDifficulty()
    {
        var difficulties = new Dictionary<int, string>()
        {
            { 1, "Child's play" },
            { 2, "Easy" },
            { 3, "Medium" },
            { 4, "Hard" },
            { 5, "Kinda tedious" }
        };
        while (true)
        {
            int response = _ui.GetDifficulty(difficulties);
            if (response is >= 1 and <= 5)
                return response;
        }
    }

    public int GetTowerHeightFromDifficulty()
    {
        return _world.Parameters.Difficulty + 2;
    }

    public Tower? MapCommandToTower(InputCommand command)
    {
        return command switch
        {
            InputCommand.TowerLeft => _world.Towers.Left,
            InputCommand.TowerMiddle => _world.Towers.Middle,
            InputCommand.TowerRight => _world.Towers.Right,
            _ => null
        };
    }

    public bool CanTakeFromTower(Tower? tower)
    {
        if (tower == null)
        {
            _world.Messages.Status = "Unknown command, try again.";
            return false;
        }
        if (tower.IsEmpty)
        {
            _world.Messages.Status = "Can not take from empty tower.";
            return false;
        }
        return true;
    }

    public bool CanMoveToTower(Tower sourceTower, Tower? targetTower)
    {
        if (targetTower == null)
        {
            _world.Messages.Status = "Unknown command, try again.";
            return false;
        }
        if (sourceTower == targetTower)
        {
            _world.Messages.Status = "Can not place on same tower, try again.";
            return false;
        }
        if (sourceTower.TopFloorSize >= targetTower.TopFloorSize)
        {
            _world.Messages.Status = "Must place on larger tower piece, try again.";
            return false;
        }
        return true;
    }

    public void MoveTowerPiece(Tower sourceTower, Tower targetTower)
    {
        var piece = sourceTower.Pop();
        targetTower.Push(piece);
    }

    public bool IsGameWon()
    {
        return _world.Towers.Left.IsEmpty
            && _world.Towers.Middle.IsEmpty;
    }

    public int GetMinimumMovesToWin()
    {
        int towerHeight = GetTowerHeightFromDifficulty();
        return (int)Math.Pow(2, towerHeight) - 1;
    }

    public void Congratulate(int movesUsed)
    {
        bool isPerfectScore = (movesUsed == GetMinimumMovesToWin());
        _world.Messages.Status = (isPerfectScore) ? "Perfect!" : "Success!";
        _world.Messages.Status += $" You completed the game in {movesUsed} moves on difficulty {_world.Parameters.Difficulty}.";
    }
}
