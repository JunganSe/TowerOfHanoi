using TowerOfHanoi.Core.Components;
using TowerOfHanoi.Core.Interfaces;

namespace TowerOfHanoi.Core.Game;

public class Worker
{
    private readonly IUi _ui;
    private readonly World _world;

    public Worker(IUi ui, World world)
    {
        _ui = ui;
        _world = world;
    }
}
