using System.Collections.Generic;

internal sealed class PieceRook : PieceBase
{
    public PieceRook(PieceColor color, int x, int y) : base(color, x, y)
    {
    }

    public override List<MoveBase> ListMoves(ChessBoard board)
    {
        var moves = new List<MoveBase>();

        //Move left
        for (var i = this.X - 1; i >= 0; i--)
        {
            moves.Add(new MoveMove(this, i, this.Y));
            if (!board.IsEmpty(i, this.Y)) break;
        }

        //Move right
        for (var i = this.X + 1; i < board.Width; i++)
        {
            moves.Add(new MoveMove(this, i, this.Y));
            if (!board.IsEmpty(i, this.Y)) break;
        }

        //Move down
        for (var i = this.Y - 1; i >= 0; i--)
        {
            moves.Add(new MoveMove(this, this.X, i));
            if (!board.IsEmpty(this.X, i)) break;
        }

        //Move up
        for (var i = this.Y + 1; i < board.Height; i++)
        {
            moves.Add(new MoveMove(this, this.X, i));
            if (!board.IsEmpty(this.X, i)) break;
        }

        return moves;
    }
}