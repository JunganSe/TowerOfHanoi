using TowerOfHanoi.Core.Game;

namespace TowerOfHanoi.ConsoleUi;

internal class Program
{
    static void Main(string[] args)
    {
        var ui = new Ui();
        var gameController = new Controller(ui);
        gameController.Run();
    }
}
