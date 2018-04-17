using System.Collections.Generic;

internal sealed class PieceKing : PieceBase
{
    public PieceKing(PieceColor color, int x, int y) : base(color, x, y)
    {
    }
    public override string Token => "k";
    public override List<MoveBase> ListMoves(ChessBoard board)
    {
        var moves = new List<MoveBase>();

        moves.Add(new MoveMove(this, this.X + 1, this.Y));
        moves.Add(new MoveMove(this, this.X - 1, this.Y));
        moves.Add(new MoveMove(this, this.X, this.Y + 1));
        moves.Add(new MoveMove(this, this.X, this.Y - 1));

        moves.Add(new MoveMove(this, this.X + 1, this.Y + 1));
        moves.Add(new MoveMove(this, this.X - 1, this.Y + 1));
        moves.Add(new MoveMove(this, this.X + 1, this.Y - 1));
        moves.Add(new MoveMove(this, this.X - 1, this.Y - 1));

        return moves;
    }
}