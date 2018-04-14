internal class MovePawnSwitch : MoveMove
{
    private PieceBase _replacement;

    public MovePawnSwitch(MoveMove move, PieceBase replacement) : base(move.Piece, move.DestX, move.DestY)
    {
        this._replacement = replacement;
    }

    public override void Perform(ChessBoard board)
    {
        base.Perform(board);

        board.RemovePiece(this.Piece);
        board.AddPiece(_replacement);
    }

    public override void Revert(ChessBoard board)
    {
        board.RemovePiece(_replacement);
        board.AddPiece(this.Piece);

        base.Revert(board);
    }
}