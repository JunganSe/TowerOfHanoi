using TowerOfHanoi.Core.Components;
using TowerOfHanoi.Core.Enums;
using TowerOfHanoi.Core.Interfaces;

namespace TowerOfHanoi.ConsoleUi;

public class Ui : IUi
{
    private readonly InputHandler _inputHandler;
    private readonly OutputHandler _outputHandler;

    public Ui()
    {
        _inputHandler = new InputHandler();
        _outputHandler = new OutputHandler();
    }

    public void Initialize()
    {
        throw new NotImplementedException();
    }

    public void Draw(World world)
    {
        throw new NotImplementedException();
    }

    public InputCommand GetInput() 
        => _inputHandler.GetInput();
}
