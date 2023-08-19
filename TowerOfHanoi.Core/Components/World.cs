using TowerOfHanoi.Core.Enums;

namespace TowerOfHanoi.Core.Components;

public class World
{
    public GameState GameState { get; set; }
    public Towers Towers { get; set; }
    public Messages Messages { get; set; }

    public World()
    {
        GameState = GameState.None;
        Towers = new Towers();
        Messages = new Messages();
    }
}
