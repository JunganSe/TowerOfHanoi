namespace TowerOfHanoi.Core.GameComponents;

public class Messages
{
    public string Instruction { get; set; } = "";
    public string Error { get; set; } = "";

    public void Clear()
    {
        Instruction = "";
        Error = "";
    }
}
