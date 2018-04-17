internal abstract class MoveBase
{
    public readonly PieceBase Piece;

    protected MoveBase(PieceBase piece)
    {
        this.Piece = piece;
    }

    public virtual void Perform(ChessBoard board)
    {
        foreach (var otherPiece in board.Pieces)
            if (otherPiece != this.Piece) otherPiece.OtherMoved(this.Piece, this);
    }

    public abstract void Revert(ChessBoard board);
    public abstract bool Validate(ChessBoard board, bool checkCheck);
}