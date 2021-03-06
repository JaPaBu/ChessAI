internal class MoveEnPassant : MoveMovePawn
{
    private readonly PiecePawn _pawn;
    public MoveEnPassant(PiecePawn piece, int destX, int destY, PiecePawn pawn) : base(piece, destX, destY)
    {
        this._pawn = pawn;
    }

    public override void Perform(ChessBoard board)
    {
        board.RemovePiece(_pawn);
        base.Perform(board);
    }

    public override void Revert(ChessBoard board)
    {
        board.AddPiece(_pawn);
        base.Revert(board);
    }
}