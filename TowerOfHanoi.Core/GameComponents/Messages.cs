namespace TowerOfHanoi.Core.GameComponents;

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
