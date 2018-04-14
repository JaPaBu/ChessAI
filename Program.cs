using System;
using System.Collections.Generic;

namespace ChessAI
{
    class Program
    {
        static void Main(string[] args)
        {
            Tests.RunAllTests();

            ChessBoard board = ChessGenerator.Classic();

            var moves = board.ListMoves(PieceColor.White);

            moves = moves.FindAll(move => move.Piece is PiecePawn);

            Console.WriteLine("Hello World!");
        }
    }
}
