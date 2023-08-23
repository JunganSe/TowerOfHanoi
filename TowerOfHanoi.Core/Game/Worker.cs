using TowerOfHanoi.Core.Components;
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
}
