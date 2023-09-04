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

    public int MapDifficultyToTowerHeight(int difficulty)
    {
        return difficulty + 2;
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

    public bool CheckCanTakeFromTower(Tower? tower)
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

    public bool CheckCanPlaceOnTower(Tower currentTower, Tower? targetTower)
    {
        if (targetTower == null)
        {
            _world.Messages.Status = "Unknown command, try again.";
            return false;
        }
        if (currentTower.TopFloorSize >= targetTower.TopFloorSize)
        {
            _world.Messages.Status = "Must place on larger tower piece, try again.";
            return false;
        }
        return true;
    }
}
