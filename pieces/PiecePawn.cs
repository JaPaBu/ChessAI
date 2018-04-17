using System.Collections.Generic;

internal sealed class PiecePawn : PieceBase
{
    public bool EnPassantAvailable = false;
    public bool HasMoved = false;
    private Direction _dir;

    public override string Token => "p";
    public PiecePawn(PieceColor color, int x, int y, Direction dir) : base(color, x, y)
    {
        this._dir = dir;
    }

    public override void OtherMoved(PieceBase piece, MoveBase move)
    {
        this.EnPassantAvailable = false;
        base.OtherMoved(piece, move);
    }
    public override List<MoveBase> ListMoves(ChessBoard board)
    {
        var moves = new List<MoveBase>();

        var x = this.X;
        var y = this.Y;

        //Every move is able to replace pawn with other piece
        void AddMoveMove(MoveMovePawn move)
        {
            var xx = move.DestX;
            var yy = move.DestY;
            _dir.MoveOne(ref xx, ref yy);
            if (board.IsInBounds(xx, yy)) moves.Add(move);
            else moves.Add(new MovePawnSwitch(move, new PieceQueen(this.Color, move.DestX, move.DestY)));
        }

        //Move one forward
        _dir.MoveOne(ref x, ref y);
        if (board.IsInBounds(x, y) && board.IsEmpty(x, y)) AddMoveMove(new MoveMovePawn(this, x, y));

        //Move two forward
        _dir.MoveOne(ref x, ref y);
        if (board.IsInBounds(x, y) && board.IsEmpty(x, y) && !HasMoved) AddMoveMove(new MoveDoubleMovePawn(this, x, y));

        //Take diagonally
        x = this.X;
        y = this.Y;
        _dir.MoveOne(ref x, ref y);
        _dir.Perpendicular.MoveOne(ref x, ref y);
        if (board.IsInBounds(x, y) && !board.IsEmpty(x, y)) AddMoveMove(new MoveMovePawn(this, x, y));

        _dir.Perpendicular.Opposite.Move(ref x, ref y, 2);
        if (board.IsInBounds(x, y) && !board.IsEmpty(x, y)) AddMoveMove(new MoveMovePawn(this, x, y));

        //En passant
        void AddEnPassant(Direction dir)
        {
            x = this.X;
            y = this.Y;
            dir.MoveOne(ref x, ref y);
            if (!board.IsInBounds(x, y)) return;

            var pawn = board.GetPiece(x, y) as PiecePawn;
            if (pawn == null || pawn.Color == this.Color || !pawn.EnPassantAvailable) return;

            _dir.MoveOne(ref x, ref y);
            if (!board.IsInBounds(x, y) || !board.IsEmpty(x, y)) return;

            AddMoveMove(new MoveEnPassant(this, x, y, pawn));
        }

        AddEnPassant(_dir.Perpendicular);
        AddEnPassant(_dir.Perpendicular.Opposite);

        return moves;
    }
}