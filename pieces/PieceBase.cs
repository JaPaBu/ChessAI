
using System;
using System.Collections.Generic;

internal abstract class PieceBase
{
    public readonly PieceColor Color;
    public int X { get; private set; }
    public int Y { get; private set; }

    public bool Exists = false;

    public abstract string Token { get; }

    public virtual bool CanBeTaken { get; } = true;
    public PieceBase(PieceColor color, int x, int y)
    {
        this.Color = color;
        this.X = x;
        this.Y = y;
    }

    public List<MoveBase> ListValidatedMoves(ChessBoard board, bool checkCheck = true)
        => ListMoves(board).FindAll(move => move.Validate(board, checkCheck));

    public void Move(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public override string ToString() => $"({this.X}; {this.Y})";


    public virtual void OtherMoved(PieceBase piece, MoveBase move) { }
    public abstract List<MoveBase> ListMoves(ChessBoard board);
}