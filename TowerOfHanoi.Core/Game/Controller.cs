using TowerOfHanoi.Core.Components;
using TowerOfHanoi.Core.Enums;
using TowerOfHanoi.Core.Interfaces;

namespace TowerOfHanoi.Core.Game;

public class Controller
{
    private readonly World _world;
    private readonly Worker _worker;
    private GameState _state;

    public int Difficulty { get; private set; }
    public int Moves { get; private set; }

    public Controller(IUi ui)
    {
        _world = new World();
        _worker = new Worker(ui, _world);
        _state = GameState.None;
    }



    public void Run()
    {
        Difficulty = _worker.SelectDifficulty();
        Initialize();
    }

    private void Initialize()
    {
        _world.Messages.Clear();
        int towerHeight = _worker.MapDifficultyToTowerHeight(Difficulty);
        _world.Towers.Initialize(towerHeight);
        _state = GameState.Take;
    }
}
