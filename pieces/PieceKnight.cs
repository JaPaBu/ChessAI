using System.Collections.Generic;

internal sealed class PieceKnight : PieceBase
{
    public PieceKnight(PieceColor color, int x, int y) : base(color, x, y)
    {
    }

    public override List<MoveBase> ListMoves(ChessBoard board)
    {
        var moves = new List<MoveBase>();
        return moves;
    }
}