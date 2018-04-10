internal class MoveDoubleMovePawn : MoveMove
{
    public MoveDoubleMovePawn(PiecePawn piece, int destX, int destY) : base(piece, destX, destY)
    {
    }

    public override void Perform(ChessBoard board)
    {
        ((PiecePawn)this.Piece).EnPassantAvailable = true;
        base.Perform(board);
    }
}