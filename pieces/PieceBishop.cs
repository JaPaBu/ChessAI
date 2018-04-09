using System.Collections.Generic;

internal sealed class PieceBishop : PieceBase
{
    public override List<MoveBase> ListMoves(ChessBoard board)
    {
        var moves = new List<MoveBase>();

        //Move up/left
        var i = this.X - 1;
        var o = this.Y + 1;
        while (i >= 0 && o < 8)
        {
            moves.Add(new MoveMove(this, i, o));
            if (board.GetPiece(i, o) != null) break;
            i--;
            o++;
        }

        //Move down/left
        i = this.X - 1;
        o = this.Y - 1;
        while (i >= 0 && o >= 0)
        {
            moves.Add(new MoveMove(this, i, o));
            if (board.GetPiece(i, o) != null) break;
            i--;
            o--;
        }

        //Move down/right
        i = this.X + 1;
        o = this.Y - 1;
        while (i < 8 && o >= 0)
        {
            moves.Add(new MoveMove(this, i, o));
            if (board.GetPiece(i, o) != null) break;
            i++;
            o--;
        }

        //Move up/right
        i = this.X + 1;
        o = this.Y + 1;
        while (i < 8 && o < 8)
        {
            moves.Add(new MoveMove(this, i, o));
            if (board.GetPiece(i, o) != null) break;
            i++;
            o++;
        }

        return moves;
    }
}