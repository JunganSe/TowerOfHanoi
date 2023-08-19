namespace TowerOfHanoi.Core.Components;

public class Messages
{
    public string Instruction { get; set; } = "";
    public string Status { get; set; } = "";

    public void Clear()
    {
        Instruction = "";
        Status = "";
    }
}
