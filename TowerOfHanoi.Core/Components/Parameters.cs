namespace TowerOfHanoi.Core.Components;

public class Parameters
{
    public Dictionary<int, string> Difficulties { get; init; }
    public int Difficulty { get; init; }

    public Parameters()
    {
        Difficulties = new() { { -1, "-Error-" } };
        Difficulty = -1;
    }
}
