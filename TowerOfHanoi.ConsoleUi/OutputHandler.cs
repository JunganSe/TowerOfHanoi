﻿using System.Drawing;
using TowerOfHanoi.Core.Components;
using TowerOfHanoi.Core.Extensions;

namespace TowerOfHanoi.ConsoleUi;

internal class OutputHandler
{
    private readonly Rectangle _playField;
    private readonly Rectangle _messageBox;
    private readonly GraphicMaker _graphicMaker;
    private readonly ConsoleColor _mainColor;
    private readonly ConsoleColor _highlightColor;
    private readonly ConsoleColor _backgroundColor;

    public OutputHandler()
    {
        _playField = new Rectangle(2, 1, 62, 12);
        _messageBox = new Rectangle(2, 13, 62, 4);
        _graphicMaker = new GraphicMaker(maxTowerHeight: 7);
        _mainColor = ConsoleColor.White;
        _highlightColor = ConsoleColor.Green;
        _backgroundColor = ConsoleColor.Black;
    }



    public void ClearScreen()
    {
        Console.Clear();
    }

    public void DrawDifficulties(Dictionary<int, string> difficulties)
    {
        Console.WriteLine("Select difficulty:");
        foreach (var d in difficulties)
            Console.WriteLine($"{d.Key}: {d.Value}");
    }

    public void ClearTowers()
    {
        int width = _playField.Width - 2;
        int height = _playField.Height - 2;
        int x = _playField.X + 1;
        int y = _playField.Y + 1;
        var filler = new string(' ', width);
        for (int i = 0; i < height; i++)
        {
            Console.SetCursorPosition(x, y + i);
            Console.Write(filler);
        }
    }

    public void DrawBorders()
    {
        ResetColors();
        DrawBox(_playField);
        DrawBox(_messageBox);
    }

    public void DrawTowers(Towers towers)
    {
        ResetColors();
        int x = _playField.X + 2;
        int y = _playField.Y + 9;

        string foundation = _graphicMaker.GetTowerFoundation();
        Console.SetCursorPosition(x, y);
        Console.Write($"{foundation}  {foundation}  {foundation}");

        string name1 = _graphicMaker.GetPaddedTowerName("1");
        string name2 = _graphicMaker.GetPaddedTowerName("2");
        string name3 = _graphicMaker.GetPaddedTowerName("3");
        Console.SetCursorPosition(x, y + 1);
        Console.Write($"{name1}  {name2}  {name3}");

        DrawTower(towers.Left, x, y);
        DrawTower(towers.Middle, x + 20, y);
        DrawTower(towers.Right, x + 40, y);
    }

    public void DrawMessages(Messages messages)
    {
        ResetColors();
        int x = _messageBox.X + 1;
        int y = _messageBox.Y + 1;
        int maxWidth = _messageBox.Width - 2;

        string status = messages.Status.Truncate(maxWidth).PadRight(maxWidth);
        Console.SetCursorPosition(x, y);
        Console.Write(status);

        string instruction = messages.Instruction.Truncate(maxWidth).PadRight(maxWidth);
        Console.SetCursorPosition(x, y + 1);
        Console.Write(instruction);
    }



    private void ResetColors()
    {
        Console.ForegroundColor = _mainColor;
        Console.BackgroundColor = _backgroundColor;
    }

    private void DrawBox(Rectangle rectangle)
    {
        int x = rectangle.X;
        int y = rectangle.Y;
        int right = rectangle.Right - 1;

        string parts = _graphicMaker.GetBorderParts();
        string horizontalLine = new string(parts[0], rectangle.Width - 2);

        Console.SetCursorPosition(x, y);
        Console.Write(parts[2] + horizontalLine + parts[3]);

        for (int i = 1; i < rectangle.Height - 1; i++)
        {
            Console.SetCursorPosition(x, y + i);
            Console.Write(parts[1]);
            Console.SetCursorPosition(right, y + i);
            Console.Write(parts[1]);
        }

        Console.SetCursorPosition(x, rectangle.Bottom - 1);
        Console.Write(parts[4] + horizontalLine + parts[5]);
    }

    private void DrawTower(Tower tower, int x, int y)
    {
        for (int i = 0; i < tower.Count; i++)
        {
            if (tower.Highlight && i == tower.Count - 1)
                Console.ForegroundColor = _highlightColor;
            else
                Console.ForegroundColor = _mainColor;

            int size = tower.Reverse().ElementAt(i).Size;
            string piece = _graphicMaker.GetTowerPiece(size);
            Console.SetCursorPosition(x + 2, y - 1 - i);
            Console.Write(piece);
        }
    }
}
