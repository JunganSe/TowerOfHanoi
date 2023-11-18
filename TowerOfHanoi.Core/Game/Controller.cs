using TowerOfHanoi.Core.Components;
using TowerOfHanoi.Core.Enums;
using TowerOfHanoi.Core.Interfaces;

namespace TowerOfHanoi.Core.Game;

public class Controller
{
    private readonly World _world;
    private readonly Worker _worker;
    private readonly IUi _ui;
    private GameState _state;
    private int _movesCount;

    public Controller(IUi ui)
    {
        _world = new World();
        _worker = new Worker(ui, _world);
        _ui = ui;
        _state = GameState.None;
        _movesCount = 0;
    }



    public void Run()
    {
        do
        {
            Initialize();
            MainLoop();
        } while (AskRestart());
        Quit();
    }

    private void Initialize()
    {
        var difficulties = _worker.CreateDifficulties();
        int difficulty = _worker.SelectDifficulty(difficulties);
        _world.Parameters = new Parameters() { Difficulties = difficulties, Difficulty = difficulty };
        _world.Messages.Clear();
        int towerHeight = _worker.GetTowerHeightFromDifficulty();
        _world.Towers.Initialize(towerHeight);
        _state = GameState.Take;
        _movesCount = 0;
    }

    private void MainLoop()
    {
        Tower? sourceTower = null;
        while (true)
        {
            if (_state == GameState.Take)
            {
                _world.Towers.ClearHighlights();
                _world.Messages.Instruction = "Select tower to take from.";
                _ui.Draw(_world);

                var command = _ui.GetInputCommand();
                if (command == InputCommand.Quit)
                    return;
                var targetTower = _worker.MapCommandToTower(command);

                _worker.SetTakeFromTowerStatusMessage(targetTower);
                if (!_worker.CanTakeFromTower(targetTower))
                    continue;

                targetTower!.Highlight = true;
                sourceTower = targetTower;
                _world.Messages.Status = $"Taking from {sourceTower!.Name} tower.";
                _ui.Draw(_world);

                _state = GameState.Place;
            }

            if (_state == GameState.Place)
            {
                _world.Messages.Instruction = "Select tower to place on.";
                _ui.Draw(_world);

                var command = _ui.GetInputCommand();
                if (command == InputCommand.Quit)
                    return;
                var targetTower = _worker.MapCommandToTower(command);

                _worker.SetMoveToTowerStatusMessage(sourceTower!, targetTower);
                if (!_worker.CanMoveToTower(sourceTower!, targetTower))
                {
                    _state = GameState.Take;
                    continue;
                }

                _worker.MoveTowerPiece(sourceTower!, targetTower!);
                _movesCount++;
                _world.Messages.Status = $"Moved from {sourceTower!.Name} tower to {targetTower!.Name} tower.";
                _ui.Draw(_world);

                if (_worker.IsGameWon())
                {
                    _worker.Congratulate(_movesCount);
                    _world.Messages.Instruction = "Press R to play again, or any key to quit.";
                    _ui.Draw(_world);
                    break;
                }

                _state = GameState.Take;
            }
        }
    }

    private bool AskRestart()
    {
        throw new NotImplementedException();
    }

    private void Quit()
    {
        // Hanteras av ui?
        throw new NotImplementedException();
    }
}
