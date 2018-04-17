using System;
using System.Collections.Generic;

internal static class Tests
{
    public static void RunAllTests()
    {
        TestClassic();
        TestEnpassant();
        TestCheckCheckCheck();
    }


    public static void TestClassic()
    {
        var board = ChessGenerator.Classic();

        //Check for empty middle
        for (var y = 2; y <= 5; y++)
            for (var x = 0; x < 8; x++)
                if (!board.IsEmpty(x, y)) throw new Exception($"There should not be a piece! {x},{y}");


        //Test white pawns
        for (var x = 0; x < 8; x++)
        {
            var pawn = board.GetPiece(x, 1) as PiecePawn;
            if (pawn == null || pawn.Color != PieceColor.White) throw new Exception($"There should be a white pawn! {x},{1}");

            var moves = pawn.ListValidatedMoves(board);
            if (!HasMoveMove(moves, x, 1, x, 2)) throw new Exception($"White pawn should be able to go one forward!" + pawn);
            if (!HasMoveMove(moves, x, 1, x, 3)) throw new Exception($"White pawn should be able to go two forward!" + pawn);

            if (moves.Count != 2) throw new Exception($"White pawn should have two moves!" + pawn);
        }

        //Test black pawns
        for (var x = 0; x < 8; x++)
        {
            var pawn = board.GetPiece(x, 6) as PiecePawn;
            if (pawn == null || pawn.Color != PieceColor.Black) throw new Exception($"There should be a black pawn!" + pawn);

            var moves = pawn.ListValidatedMoves(board);
            if (!HasMoveMove(moves, x, 6, x, 5)) throw new Exception($"Black pawn should be able to go one forward!" + pawn);
            if (!HasMoveMove(moves, x, 6, x, 4)) throw new Exception($"Black pawn should be able to go two forward!" + pawn);

            if (moves.Count != 2) throw new Exception($"White pawn should have two moves!" + pawn);
        }

        if (board.ListMoves(PieceColor.White).Count != 20) throw new Exception($"White should have 20 moves!");
        if (board.ListMoves(PieceColor.Black).Count != 20) throw new Exception($"Black should have 20 moves!");
    }

    private static void TestEnpassant()
    {
        var board = new ChessBoard(2, 4);

        var blackPawn = new PiecePawn(PieceColor.Black, 0, 3, Direction.Down);
        var whitePawn = new PiecePawn(PieceColor.White, 1, 1, Direction.Up);

        board.AddPiece(blackPawn);
        board.AddPiece(whitePawn);

        var blackPawnMoves = blackPawn.ListMoves(board);
        if (blackPawnMoves.Count != 2) throw new Exception("Black pawn should have two moves!" + blackPawn);

        var doubleMove = blackPawnMoves.Find(move => move is MoveDoubleMovePawn) as MoveDoubleMovePawn;
        if (doubleMove == null) throw new Exception("Black pawn should be able to doublemove!" + blackPawn);
        doubleMove.Perform(board);

        var whiteMoves = whitePawn.ListValidatedMoves(board);
        if (whiteMoves.Count != 3) throw new Exception("White pawn should have two moves!" + whitePawn);


        var enPassant = whiteMoves.Find(move => move is MoveEnPassant) as MoveEnPassant;
        if (enPassant == null) throw new Exception("White pawn should be able to en passant!" + whitePawn);
        enPassant.Perform(board);

        if (blackPawn.Exists) throw new Exception("Black pawn should have been taken!" + blackPawn);

        if (board.GetPiece(0, 2) != whitePawn) throw new Exception("White pawn should be at (0,2)!" + blackPawn);
    }

    private static void TestCheckCheckCheck()
    {
        var board = new ChessBoard(8, 8);

        //board.AddPiece(new PieceBishop(PieceColor.Black, 0, 0));
        board.AddPiece(new PieceQueen(PieceColor.Black, 6, 6));

        var whiteKing = new PieceKing(PieceColor.White, 7, 7);
        board.AddPiece(whiteKing);

        var moves = whiteKing.ListValidatedMoves(board);

        if (board.IsCheckMate(PieceColor.White))
            Console.WriteLine("Checkmate");
        else if (board.IsPatt(PieceColor.White))
            Console.WriteLine("Patt");
        else
            Console.WriteLine("King can move " + moves);

        board.Print();
    }

    private static bool HasMoveMove(List<MoveBase> list, int srcX, int srcY, int destX, int destY)
        => list.FindAll(move => move is MoveMove).ConvertAll<MoveMove>(move => (MoveMove)move)
            .Exists(move => move.Piece.X == srcX && move.Piece.Y == srcY && move.DestX == destX && move.DestY == destY);
}