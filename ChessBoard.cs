
using System;
using System.Collections.Generic;

internal sealed class ChessBoard
{
    private readonly PieceBase[,] _board;

    public readonly int Width;
    public readonly int Height;

    public PieceColor Turn { private set; get; } = PieceColor.White;

    public ChessBoard(int width, int height)
    {
        this.Width = width;
        this.Height = height;
        _board = new PieceBase[width, height];
    }

    private void CheckPositionBounds(int x, int y)
    {
        if (x < 0 || x >= Width || y < 0 || y >= Width)
            throw new Exception("Position out of bounds!");
    }
    public PieceBase GetPiece(int x, int y)
    {
        CheckPositionBounds(x, y);
        return _board[x, y];
    }

    public void SetPiece<T>(PieceColor color, int x, int y) where T : PieceBase, new()
    {
        CheckPositionBounds(x, y);

        if (_board[x, y] != null) throw new Exception("There is already a piece!");

        var piece = new T();
        piece.Init(color, x, y);

        _board[x, y] = piece;
    }

    public void RemovePiece(int x, int y)
    {
        CheckPositionBounds(x, y);

        if (_board[x, y] == null) throw new Exception("There is no piece!");
        _board[x, y] = null;
    }

    public void SetTurn(PieceColor turn) => Turn = turn;

    public List<MoveBase> ListMoves(PieceColor color)
    {
        var moves = new List<MoveBase>();

        for (var x = 0; x < Width; x++)
            for (var y = 0; y < Height; y++)
            {
                var piece = _board[x, y];
                if (piece == null && piece.Color == color) continue;

                moves.AddRange(piece.ListMoves(this));
            }

        return moves.FindAll(move => move.Validate(this));
    }
}