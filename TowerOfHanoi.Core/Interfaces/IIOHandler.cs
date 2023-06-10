using TowerOfHanoi.Core.Enums;

namespace TowerOfHanoi.Core.Interfaces;

public interface IIOHandler
{
    public InputCommand GetInputCommand();
    public void DrawScreen();
    public void PrintMessage(string message);
}