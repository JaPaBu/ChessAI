internal sealed class MoveMove : MoveBase
{
    public readonly int DestX;
    public readonly int DestY;

    public MoveMove(PieceBase piece, int destX, int destY) : base(piece)
    {

        this.DestX = destX;
        this.DestY = destY;
    }

    public override bool Validate(ChessBoard board)
    {
        var destPiece = board.GetPiece(DestX, DestY);

        if (destPiece != null)
        {
            //Cant take own pieces
            if (destPiece.Color == Piece.Color)
                return false;

            //Cant take kings
            if (!destPiece.CanBeTaken)
                return false;
        }

        //TODO: Check self check

        return true;
    }
    public override void Perform(ChessBoard board)
    {

    }
}