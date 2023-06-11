using TowerOfHanoi.Core.Enums;

namespace TowerOfHanoi.Core;

public partial class Game
{
    private bool HandleEscapeInput(InputCommand command)
    {
        switch (command)
        {
            case InputCommand.Restart:
                _keepLooping = false;
                _restart = true;
                return true;
            case InputCommand.Quit:
                _keepLooping = false;
                _restart = false;
                return true;
            default:
                return false;
        }
    }

    private bool HandleTakeInput(InputCommand command)
    {
        return command switch
        {
            InputCommand.TowerLeft => TryTargetTower(Towers.Left),
            InputCommand.TowerMiddle => TryTargetTower(Towers.Middle),
            InputCommand.TowerRight => TryTargetTower(Towers.Right),
            _ => false
        };
    }
}
