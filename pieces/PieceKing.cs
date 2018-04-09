using System.Collections.Generic;

internal sealed class PieceKing : PieceBase
{
    public override bool CanBeTaken { get; } = false;
    public override List<MoveBase> ListMoves(ChessBoard board)
    {
        var moves = new List<MoveBase>();
        return moves;
    }
}