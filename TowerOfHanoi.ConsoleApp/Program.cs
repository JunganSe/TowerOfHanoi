using TowerOfHanoi.Core;

namespace TowerOfHanoi.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        var playField = new Rectangle(2, 2, 50, 20);
        var messageBox = new Rectangle(2, 2, 50, 4);
        var drawHandler = new DrawHandler(playField, messageBox);
        var ioHandler = new IOHandler(drawHandler);
        var game = new Game(ioHandler);
        game.Run();
    }
}
