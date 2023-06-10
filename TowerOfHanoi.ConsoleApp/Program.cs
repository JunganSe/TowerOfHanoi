using TowerOfHanoi.Core;

namespace TowerOfHanoi.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        var drawHandler = new DrawHandler();
        var ioHandler = new IOHandler(drawHandler);
        var game = new Game(ioHandler);
        game.Run();
    }
}
