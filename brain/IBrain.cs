using System.Collections.Generic;

interface IBrain
{
    MoveBase GetMove(ChessBoard board, List<MoveBase> moves, PieceColor color);
}