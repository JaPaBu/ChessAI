using System.Collections.Generic;

internal sealed class PieceKing : PieceBase
{
    public PieceKing(PieceColor color, int x, int y) : base(color, x, y)
    {
    }

    public override bool CanBeTaken { get; } = false;
    public override List<MoveBase> ListMoves(ChessBoard board)
    {
        var moves = new List<MoveBase>();
        return moves;
    }
}