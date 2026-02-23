using TowerOfHanoi.Core.Enums;
using TowerOfHanoi.Core.GameComponents;

namespace TowerOfHanoi.Core.Interfaces;

public interface IIOHandler
{
    public char GetInputChar();
    public InputCommand GetInputCommand();
    public void ClearScreen();
    public void Initialize();
    public void DrawTowers(Towers towers);
    public void DrawMessages(Messages messages);
    public void PrintMessage(string message);
}