using System;

internal class MoveMove : MoveBase
{
    public readonly int DestX;
    public readonly int DestY;

    private int _movedFromX;
    private int _movedFromY;
    private PieceBase _taken;
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

        var isValid = true;
        this.Perform(board);
        if (board.IsCheck(this.Piece.Color)) isValid = false;
        this.Revert(board);

        return isValid;
    }
    public override void Perform(ChessBoard board)
    {
        var existingPiece = board.GetPiece(this.DestX, this.DestY);
        if (existingPiece != null)
            board.RemovePiece(existingPiece);


        this._taken = existingPiece;
        this._movedFromX = this.Piece.X;
        this._movedFromY = this.Piece.Y;
        board.MovePiece(this.Piece, this.DestX, this.DestY);
    }

    public override void Revert(ChessBoard board)
    {
        board.MovePiece(this.Piece, this._movedFromX, this._movedFromY);

        if (this._taken != null)
            board.AddPiece(this._taken);

        this._taken = null;
    }
}