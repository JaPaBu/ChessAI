
using System;
using System.Collections.Generic;

internal abstract class PieceBase
{
    private bool _initialized = false;

    public PieceColor Color { get; private set; }
    public int X { get; private set; }
    public int Y { get; private set; }

    public virtual bool CanBeTaken { get; } = true;

    public PieceBase() { }

    public void Init(PieceColor color, int x, int y)
    {
        if (_initialized) throw new Exception("Piece can only be initialized once!");

        this.Color = color;
        this.X = x;
        this.Y = y;

        this._initialized = true;
    }
    public abstract List<MoveBase> ListMoves(ChessBoard board);
}