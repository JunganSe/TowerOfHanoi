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

    public int Difficulty { get; private set; }
    public int Moves { get; private set; }

    public Controller(IUi ui)
    {
        _world = new World();
        _worker = new Worker(ui, _world);
        _ui = ui;
        _state = GameState.None;
    }



    public void Run()
    {
        bool restart = true;
        while (restart)
        {
            Difficulty = _worker.SelectDifficulty();
            Initialize();
            MainLoop();
            // Kolla om spelaren vann eller avbröt. Om vann, gratulera och visa antal moves.
            restart = AskRestart();
        }
        Quit();
    }

    private void Initialize()
    {
        _world.Messages.Clear();
        int towerHeight = _worker.MapDifficultyToTowerHeight(Difficulty);
        _world.Towers.Initialize(towerHeight);
        _state = GameState.Take;
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

                if (!_worker.CanMoveToTower(sourceTower!, targetTower))
                {
                    _state = GameState.Take;
                    continue;
                }

                _worker.MoveTowerPiece(sourceTower!, targetTower!);
                _world.Messages.Status = $"Moved from {sourceTower!.Name} tower to {targetTower!.Name} tower.";
                _ui.Draw(_world);

                // TODO: Check for win

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
