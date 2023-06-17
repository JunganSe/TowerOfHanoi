using TowerOfHanoi.Core.Enums;
using TowerOfHanoi.Core.GameComponents;

namespace TowerOfHanoi.Core;

public partial class Game
{
    public void SelectDifficulty()
    {
        string message = "Select Difficulty:\n" +
            "1. Child's play\n" +
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
                break;
            }
        }
    }

    private void Initialize()
    {
        _ioHandler.ClearScreen();
        int towerHeight = MapDifficultyToTowerHeight(Difficulty);
        Towers.Initialize(towerHeight);
        Messages.Clear();
        Moves = 0;
        _keepLooping = true;
        _state = GameState.Take;
    }

    private int MapDifficultyToTowerHeight(int difficulty)
        => difficulty + 2;

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
}
