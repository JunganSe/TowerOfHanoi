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



    public Dictionary<int, string> CreateDifficulties()
    {
        return new Dictionary<int, string>()
        {
            { 1, "Child's play" },
            { 2, "Easy" },
            { 3, "Medium" },
            { 4, "Hard" },
            { 5, "Kinda tedious" }
        };
    }

    public int SelectDifficulty(Dictionary<int, string> difficulties)
    {
        while (true)
        {
            int response = _ui.GetDifficulty(difficulties);
            if (difficulties.ContainsKey(response))
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

    public void SetTakeFromTowerStatusMessage(Tower? tower)
    {
        if (tower == null)
            _world.Messages.Status = "Unknown command, try again.";
        else if (tower.IsEmpty)
            _world.Messages.Status = "Can not take from an empty tower.";
    }

    public bool CanTakeFromTower(Tower? tower)
    {
        return !(tower == null 
            || tower.IsEmpty);
    }

    public void SetMoveToTowerStatusMessage(Tower sourceTower, Tower? targetTower)
    {
        if (targetTower == null)
            _world.Messages.Status = "Unknown command, try again.";
        else if (sourceTower == targetTower)
            _world.Messages.Status = "Can not place on the same tower, try again.";
        else if (sourceTower.TopFloorSize >= targetTower.TopFloorSize)
            _world.Messages.Status = "Must place on larger tower piece, try again.";
    }

    public bool CanMoveToTower(Tower sourceTower, Tower? targetTower)
    {
        return !(targetTower == null
            || sourceTower == targetTower
            || sourceTower.TopFloorSize >= targetTower.TopFloorSize);
    }

    public void MoveTowerPiece(Tower sourceTower, Tower targetTower)
    {
        var piece = sourceTower.Pop();
        targetTower.Push(piece);
    }

    public bool IsGameWon()
    {
        return _world.Towers.Right.Count == GetTowerHeightFromDifficulty();
    }

    public int GetMinimumMovesToWin()
    {
        int towerHeight = GetTowerHeightFromDifficulty();
        return (int)Math.Pow(2, towerHeight) - 1;
    }

    public void Congratulate(int movesUsed)
    {
        bool isPerfectScore = (movesUsed == GetMinimumMovesToWin());
        _world.Messages.Status = (isPerfectScore? "Perfect!" : "Success!")
            + $" Game completed in {movesUsed} moves on difficulty {_world.Parameters.Difficulty}.";
    }

    public bool AskRestart()
    {
        _world.Messages.Instruction = "Press R to play again, or any other key to quit.";
        _ui.Draw(_world);
        return _ui.GetInputCommand() == InputCommand.Restart;
    }
}
