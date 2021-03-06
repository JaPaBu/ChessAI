using System;
using System.Collections.Generic;

internal sealed class ChessBoard
{
    public readonly PieceBase[,] Pieces;

    public readonly int Width;
    public readonly int Height;

    public PieceColor Turn { private set; get; } = PieceColor.White;

    public ChessBoard(int width, int height)
    {
        this.Width = width;
        this.Height = height;
        this.Pieces = new PieceBase[this.Width, this.Height];
    }

    private void EnsurePositionBounds(int x, int y)
    {
        if (!IsInBounds(x, y))
            throw new Exception("Position out of bounds!");
    }

    public bool IsInBounds(int x, int y) => x >= 0 && x < Width && y >= 0 && y < Height;
    public PieceBase GetPiece(int x, int y)
    {
        EnsurePositionBounds(x, y);
        return Pieces[x, y];
    }

    public void AddPiece(PieceBase piece)
    {
        EnsurePositionBounds(piece.X, piece.Y);

        if (Pieces[piece.X, piece.Y] != null) throw new Exception("There is already a piece!");
        piece.Exists = true;
        Pieces[piece.X, piece.Y] = piece;
    }

    public void RemovePiece(PieceBase piece)
    {
        EnsurePositionBounds(piece.X, piece.Y);

        if (Pieces[piece.X, piece.Y] == null) throw new Exception("There is no piece!");
        piece.Exists = false;
        Pieces[piece.X, piece.Y] = null;
    }

    public void MovePiece(PieceBase piece, int destX, int destY)
    {
        EnsurePositionBounds(destX, destY);

        if (Pieces[piece.X, piece.Y] != piece) throw new Exception("Piece is not where it should be!");
        if (Pieces[destX, destY] != null) throw new Exception("Cant move because there is already a piece!");

        RemovePiece(piece);
        piece.Move(destX, destY);
        AddPiece(piece);
    }

    public bool IsEmpty(int x, int y)
    {
        EnsurePositionBounds(x, y);
        return Pieces[x, y] == null;
    }

    public void SetTurn(PieceColor turn) => Turn = turn;

    public List<MoveBase> ListMoves(PieceColor color, bool checkCheck = true)
    {
        var moves = new List<MoveBase>();

        for (var x = 0; x < Width; x++)
            for (var y = 0; y < Height; y++)
            {
                var piece = Pieces[x, y];
                if (piece == null || piece.Color != color) continue;

                moves.AddRange(piece.ListValidatedMoves(this, checkCheck));
            }

        return moves;
    }

    public bool IsCheck(PieceColor color)
    {
        var kings = new List<PieceKing>();
        foreach (var piece in Pieces)
            if (piece is PieceKing king) kings.Add(king);

        return kings.Exists(king
            => PieceColor.Colors.FindAll(c => c != color)
            .Exists(otherColor
                => ListMoves(otherColor, false).FindAll(move => move is MoveMove).ConvertAll<MoveMove>(move => (MoveMove)move)
                    .Exists(move => move.DestX == king.X && move.DestY == king.Y)));
    }

    public bool IsCheckMate(PieceColor color)
    {
        return ListMoves(color).Count <= 0 && IsCheck(color);
    }

    public bool IsPatt(PieceColor color)
    {
        return ListMoves(color).Count <= 0 && !IsCheck(color);
    }

    public void Print()
    {
        var oldColor = Console.ForegroundColor;
        for (var y = Height - 1; y >= 0; y--)
        {
            for (var x = 0; x < Width; x++)
            {
                var piece = GetPiece(x, y);
                Console.ForegroundColor = piece?.Color?.ConsoleColor ?? ConsoleColor.Gray;
                Console.Write(piece?.Token ?? "x");
            }
            Console.WriteLine();
        }

        Console.ForegroundColor = oldColor;
        Console.WriteLine();
    }
}