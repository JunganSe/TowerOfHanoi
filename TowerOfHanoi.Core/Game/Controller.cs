using TowerOfHanoi.Core.Components;
using TowerOfHanoi.Core.Enums;
using TowerOfHanoi.Core.Interfaces;

namespace TowerOfHanoi.Core.Game;

public class Controller
{
    private readonly IUi _ui;
    private readonly World _world;
    private readonly Worker _worker;

    private GameState _state;
    private int _movesCount;
    private Tower? _sourceTower;

    public Controller(IUi ui)
    {
        _ui = ui;
        _world = new World();
        _worker = new Worker(ui, _world);

        _state = GameState.None;
        _movesCount = 0;
    }



    public void Run()
    {
        do
        {
            Initialize();
            MainLoop();
            End();
        } while (_worker.AskRestart());
        _ui.Quit();
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
        _ui.Initialize();
    }

    private void MainLoop()
    {
        while (true)
        {
            if (_state == GameState.Take)
                Take();
            if (_state == GameState.Place)
                Place();
            if (_state == GameState.Quit)
                return;
        }
    }

    private void Take()
    {
        _world.Towers.ClearHighlights();
        _world.Messages.Instruction = "Select tower to take from.";
        _ui.Draw(_world);

        var command = _ui.GetInputCommand();
        if (command == InputCommand.Quit)
        {
            _world.Messages.Status = "";
            _state = GameState.Quit;
            return;
        }
        var targetTower = _worker.MapCommandToTower(command);

        _worker.SetTakeFromTowerStatusMessage(targetTower);
        if (!_worker.CanTakeFromTower(targetTower))
            return;

        targetTower!.Highlight = true;
        _sourceTower = targetTower;
        _world.Messages.Status = $"Taking from {_sourceTower!.Name}.";
        _ui.Draw(_world);

        _state = GameState.Place;
    }

    private void Place()
    {
        _world.Messages.Instruction = "Select tower to place onto.";
        _ui.Draw(_world);

        var command = _ui.GetInputCommand();
        if (command == InputCommand.Quit)
        {
            _world.Messages.Status = "";
            _state = GameState.Quit;
            return;
        }
        var targetTower = _worker.MapCommandToTower(command);

        _worker.SetMoveToTowerStatusMessage(_sourceTower!, targetTower);
        if (!_worker.CanMoveToTower(_sourceTower!, targetTower))
        {
            _state = GameState.Take;
            return;
        }

        _worker.MoveTowerPiece(_sourceTower!, targetTower!);
        _movesCount++;
        _world.Messages.Status = $"Moved from {_sourceTower!.Name} to {targetTower!.Name}.";
        _ui.Draw(_world);

        if (_worker.IsGameWon())
        {
            _state = GameState.Quit;
            return;
        }

        _state = GameState.Take;
    }

    private void End()
    {
        if (_worker.IsGameWon())
        {
            _worker.Congratulate(_movesCount);
            _ui.Draw(_world);
        }
    }
}
