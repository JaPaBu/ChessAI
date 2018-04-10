
using System;
using System.Collections.Generic;

internal abstract class PieceBase
{
    public readonly PieceColor Color;
    public int X { get; private set; }
    public int Y { get; private set; }

    public virtual bool CanBeTaken { get; } = true;
    public PieceBase(PieceColor color, int x, int y)
    {
        this.Color = color;
        this.X = x;
        this.Y = y;
    }

    public virtual void Move(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public virtual void OtherMoved(PieceBase piece, MoveBase move) { }
    public abstract List<MoveBase> ListMoves(ChessBoard board);
}