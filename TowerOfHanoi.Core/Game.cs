using TowerOfHanoi.Core.GameComponents;
using TowerOfHanoi.Core.Interfaces;

namespace TowerOfHanoi.Core;

public class Game
{
    private readonly IIOHandler _ioHandler;
    private bool _restart = true;
    private bool _keepLooping = true;

    public Towers Towers { get; set; } = new();
    public Messages Messages { get; private set; } = new();
    public int Difficulty { get; private set; }
    public int TowerHeight { get; set; }
    public int Moves { get; private set; }

    public Game(IIOHandler ioHandler)
    {
        _ioHandler = ioHandler;
    }



    public void Run()
    {
        while (_restart)
        {
            _ioHandler.ClearScreen();
            SelectDifficulty();
            Initialize();
            while (_keepLooping)
            {
                MainLoop();
                CheckFinish();
            }
            Finish();
        }
        Quit();
    }

    private void SelectDifficulty()
    {
        string message = "Select Difficulty:\n" +
            "1. Ridiculusly easy\n" +
            "2. Easy\n" +
            "3. Medium\n" +
            "4. Hard\n" +
            "5. Kinda tedious";
        _ioHandler.PrintMessage(message);
        while (true)
        {
            var input = _ioHandler.GetInputChar().ToString();
            if (int.TryParse(input, out int parsed)
                && (parsed is >= 1 and <= 5))
            {
                Difficulty = parsed;
                TowerHeight = parsed + 2;
                break;
            }
        }
    }

    private void Initialize()
    {
        _ioHandler.ClearScreen();
        Towers.Initialize(TowerHeight);
        Messages.Clear();
        Moves = 0;
        _keepLooping = true;
    }

    private void MainLoop()
    {
        // - Uppdatera meddelande.
        // - Ta input för att plocka upp våning. (Och restart/quit)
        // - Kontrollera att våning kan plockas upp.
        //   - Om inte, meddela och ta input igen.
        // - Markera vald våning.
        // - Uppdatera meddelande.
        // - Ta input för att lägga ner våning. (Och restart/quit)
        // - Kontrollera att våning kan läggas ner.
        //   - Om inte, meddela och lägg tillbaka våning. Börja om.
        // - Lägg ner våning.
    }

    private void HandleInput()
    {
        // - Hämta input.
        // - Kolla och hantera om användaren vill avsluta eller börja om.
    }

    private void CheckFinish()
    {
        // - Kolla om alla våningar är på högra sidan.
    }

    private void Finish()
    {
        // - Beräkna bästa möjliga poäng för svårighetsgraden.
        // - Meddela hur det gick.
        // - Fråga: Börja om eller avsluta.
    }

    private void Restart()
    {
        // - Börja om med att välja svårighetsgrad.
    }

    private void Quit()
    {
        // Stäng ner spelet genom att anropa metod i ui-appen?
    }
}
