using System;
using System.Collections.Generic;

namespace ChessAI
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessBoard board = ChessGenerator.Test();

            var moves = board.ListMoves(PieceColor.White);

            moves = moves.FindAll(move => move.Piece is PieceBishop);

            Console.WriteLine("Hello World!");
        }
    }
}
