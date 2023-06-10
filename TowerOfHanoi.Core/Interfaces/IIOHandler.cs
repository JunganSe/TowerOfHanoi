using TowerOfHanoi.Core.Enums;

namespace TowerOfHanoi.Core.Interfaces;

public interface IIOHandler
{
    public char GetInputChar();
    public InputCommand GetInputCommand();
    public void ClearScreen();
    public void DrawScreen();
    public void PrintMessage(string message);
}