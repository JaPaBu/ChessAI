using System;

internal class MoveMove : MoveBase
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
        if (!board.IsInBounds(this.DestX, this.DestY))
            return false;

        var destPiece = board.GetPiece(this.DestX, this.DestY);

        if (destPiece != null)
        {
            //Cant take own pieces
            if (destPiece.Color == this.Piece.Color)
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
        var existingPiece = board.GetPiece(this.DestX, this.DestY);
        if (existingPiece != null)
        {
            board.RemovePiece(existingPiece);
            Console.WriteLine(existingPiece + " was taken by " + this.Piece);
        }

        board.MovePiece(this.Piece, this.DestX, this.DestY);
    }
}