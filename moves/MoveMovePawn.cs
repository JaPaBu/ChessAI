internal class MoveMovePawn : MoveMove
{
    private bool _fromMoved = false;
    public MoveMovePawn(PiecePawn piece, int destX, int destY) : base(piece, destX, destY)
    {
    }

    public override void Perform(ChessBoard board)
    {
        _fromMoved = ((PiecePawn)this.Piece).HasMoved;
        base.Perform(board);
    }

    public override void Revert(ChessBoard board)
    {
        ((PiecePawn)this.Piece).HasMoved = _fromMoved;
        base.Revert(board);
    }
}