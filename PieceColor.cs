using System;
using System.Collections.Generic;

internal class PieceColor
{
    public static readonly List<PieceColor> Colors = new List<PieceColor>();

    public static PieceColor White = new PieceColor(ConsoleColor.Blue);
    public static PieceColor Black = new PieceColor(ConsoleColor.Red);

    public readonly ConsoleColor ConsoleColor;

    private PieceColor(ConsoleColor consoleColor)
    {
        this.ConsoleColor = consoleColor;
        Colors.Add(this);
    }
}