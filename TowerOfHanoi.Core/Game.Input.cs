using TowerOfHanoi.Core.Enums;
using TowerOfHanoi.Core.GameComponents;

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

    private Tower? MapCommandToTower(InputCommand command)
    {
        return command switch
        {
            InputCommand.TowerLeft => Towers.Left,
            InputCommand.TowerMiddle => Towers.Middle,
            InputCommand.TowerRight => Towers.Right,
            _ => null
        };
    }
}
