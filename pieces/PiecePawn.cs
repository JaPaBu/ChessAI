using System.Collections.Generic;

internal sealed class PiecePawn : PieceBase
{
    private bool _hasMoved = false;

    public override void Move(int x, int y)
    {
        _hasMoved = true;
        base.Move(x, y);
    }
    public override List<MoveBase> ListMoves(ChessBoard board)
    {
        var moves = new List<MoveBase>();

        //TODO: Check whether to go up or down
        if (board.IsFree(this.X, this.Y))
        { }

        return moves;
    }
}