using System.Collections.Generic;

internal sealed class PieceQueen : PieceBase
{
    public PieceQueen(PieceColor color, int x, int y) : base(color, x, y)
    {
    }
    public override string Token => "q";

    public override List<MoveBase> ListMoves(ChessBoard board)
    {
        var moves = new List<MoveBase>();

        var rook = new PieceRook(this.Color, this.X, this.Y);
        moves.AddRange(rook.ListMoves(board));

        var bishop = new PieceBishop(this.Color, this.X, this.Y);
        moves.AddRange(bishop.ListMoves(board));

        return moves;
    }
}