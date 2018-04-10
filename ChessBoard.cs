
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
        Pieces = new PieceBase[width, height];
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
        Pieces[piece.X, piece.Y] = piece;
    }

    public void RemovePiece(PieceBase piece)
    {
        EnsurePositionBounds(piece.X, piece.Y);

        if (Pieces[piece.X, piece.Y] == null) throw new Exception("There is no piece!");
        Pieces[piece.X, piece.Y] = null;
    }

    public void MovePiece(PieceBase piece, int x, int y)
    {
        EnsurePositionBounds(x, y);

        if (Pieces[piece.X, piece.Y] != piece) throw new Exception("Piece is not where it should be!");
        if (Pieces[piece.X, piece.Y] != null) throw new Exception("Cant move because there is already a piece!");

        piece.Move(x, y);
        Pieces[x, y] = piece;
    }

    public bool IsEmpty(int x, int y)
    {
        EnsurePositionBounds(x, y);
        return Pieces[x, y] == null;
    }

    public void SetTurn(PieceColor turn) => Turn = turn;

    public List<MoveBase> ListMoves(PieceColor color)
    {
        var moves = new List<MoveBase>();

        for (var x = 0; x < Width; x++)
            for (var y = 0; y < Height; y++)
            {
                var piece = Pieces[x, y];
                if (piece == null || piece.Color != color) continue;

                moves.AddRange(piece.ListMoves(this));
            }

        return moves.FindAll(move => move.Validate(this));
    }
}