namespace TowerOfHanoi.Core.Components;

public class Parameters
{
    public Dictionary<int, string> Difficulties { get; init; } = new() { { -1, "-Error-" } };
    public int Difficulty { get; init; } = -1;
}
