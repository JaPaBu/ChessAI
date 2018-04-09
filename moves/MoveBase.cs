internal abstract class MoveBase
{
    public readonly PieceBase Piece;

    protected MoveBase(PieceBase piece)
    {
        this.Piece = piece;
    }

    public abstract bool Validate(ChessBoard board);
    public abstract void Perform(ChessBoard board);
}