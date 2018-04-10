internal class MovePawnSwitch : MoveMove
{
    private PieceBase _replacement;

    public MovePawnSwitch(MoveMove move, PieceBase replacement) : base(move.Piece, move.DestX, move.DestY)
    {
        this._replacement = replacement;
    }

    public override void Perform(ChessBoard board)
    {
        //Move
        base.Perform(board);

        //Then replace the piece
        board.RemovePiece(this.Piece);
        board.AddPiece(_replacement);
    }
}