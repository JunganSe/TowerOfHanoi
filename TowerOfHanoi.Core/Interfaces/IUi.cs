using TowerOfHanoi.Core.Components;
using TowerOfHanoi.Core.Enums;

namespace TowerOfHanoi.Core.Interfaces;

public interface IUi
{
    public void Initialize();
    public void Draw(World world);
    public InputCommand GetInput();
}
