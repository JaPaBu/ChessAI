internal class MoveDoubleMovePawn : MoveMovePawn
{
    public MoveDoubleMovePawn(PiecePawn piece, int destX, int destY) : base(piece, destX, destY)
    {
    }

    public override void Perform(ChessBoard board)
    {
        ((PiecePawn)this.Piece).EnPassantAvailable = true;
        base.Perform(board);
    }

    public override void Revert(ChessBoard board)
    {
        ((PiecePawn)this.Piece).EnPassantAvailable = false;
        base.Revert(board);
    }
}