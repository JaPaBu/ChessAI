using System.Collections.Generic;

internal sealed class PieceKnight : PieceBase
{
    public PieceKnight(PieceColor color, int x, int y) : base(color, x, y)
    {
    }

    public override List<MoveBase> ListMoves(ChessBoard board)
    {
        var moves = new List<MoveBase>();

        void AddDirection(Direction dir)
        {
            var x = this.X;
            var y = this.Y;

            dir.Move(ref x, ref y, 2);
            dir.Perpendicular.MoveOne(ref x, ref y);
            moves.Add(new MoveMove(this, x, y));
            dir.Perpendicular.Opposite.Move(ref x, ref y, 2);
            moves.Add(new MoveMove(this, x, y));
        }

        var currDir = Direction.Up;
        for (var i = 0; i < 4; i++)
            AddDirection(currDir = currDir.Perpendicular);

        return moves;
    }
}