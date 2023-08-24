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
        bool restart = false;
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
        while (true)
        {
            if (_state == GameState.Take)
            {
                _world.Messages.Instruction = "Select tower to take from.";
                _ui.Draw(_world);

                var command = _ui.GetInput();
                if (command == InputCommand.Quit)
                    return;
                var targetTower = _worker.MapCommandToTower(command);

                if (!_worker.CheckTargetTower(targetTower))
                    continue;
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
