using System;
using System.Collections.Generic;
using System.Threading;

namespace ChessAI
{
    class Program
    {
        private static void TrainingThread()
        {
            AntonBrainGenerator.GenerateBrains();
        }
        private static void NetworkThread()
        {
            MoveBase onRequest(ChessBoard board, PieceColor color)
            {
                var moves = board.ListMoves(color);
                return BrainManager.Brain.GetMove(board, moves, color);
            }

            //Accept incoming connections
            //Retrieve board status
            //Send best move
        }

        static void Main(string[] args)
        {
            Tests.RunAllTests();

            var trainingThread = new Thread(TrainingThread);
            var networkThread = new Thread(NetworkThread);

            while (true)
            {
                var cmd = Console.ReadLine();
                if (cmd.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
                    break;
                else Console.WriteLine("Unknown command");
            }
        }
    }
}
