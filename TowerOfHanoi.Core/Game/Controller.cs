using TowerOfHanoi.Core.Components;
using TowerOfHanoi.Core.Enums;
using TowerOfHanoi.Core.Interfaces;

namespace TowerOfHanoi.Core.Game;

public class Controller
{
    private readonly World _world;
    private readonly Worker _worker;
    private GameState _state;

    public Controller(IUi ui)
    {
        _world = new World();
        _worker = new Worker(ui, _world);
        _state = GameState.None;
    }



    public void Run()
    {

    }
}
