namespace TowerOfHanoi.Core.Components;

public class World
{
    public Towers Towers { get; set; }
    public Messages Messages { get; set; }

    public World()
    {
        Towers = new Towers();
        Messages = new Messages();
    }
}
