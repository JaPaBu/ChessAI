internal static class ChessGenerator
{
    public static ChessBoard Classic()
    {
        const int BOARD_WIDTH = 8;
        const int BOARD_HEIGHT = 8;

        var board = new ChessBoard(BOARD_WIDTH, BOARD_HEIGHT);

        //White backline
        board.AddPiece(new PieceRook(PieceColor.White, 0, 0));
        board.AddPiece(new PieceKnight(PieceColor.White, 1, 0));
        board.AddPiece(new PieceBishop(PieceColor.White, 2, 0));
        board.AddPiece(new PieceQueen(PieceColor.White, 3, 0));
        board.AddPiece(new PieceKing(PieceColor.White, 4, 0));
        board.AddPiece(new PieceBishop(PieceColor.White, 5, 0));
        board.AddPiece(new PieceKnight(PieceColor.White, 6, 0));
        board.AddPiece(new PieceRook(PieceColor.White, 7, 0));

        //White frontline
        for (var i = 0; i < 8; i++)
            board.AddPiece(new PiecePawn(PieceColor.White, i, 1, Direction.Up));

        //Black backline
        board.AddPiece(new PieceRook(PieceColor.Black, 0, 7));
        board.AddPiece(new PieceKnight(PieceColor.Black, 1, 7));
        board.AddPiece(new PieceBishop(PieceColor.Black, 2, 7));
        board.AddPiece(new PieceQueen(PieceColor.Black, 3, 7));
        board.AddPiece(new PieceKing(PieceColor.Black, 4, 7));
        board.AddPiece(new PieceBishop(PieceColor.Black, 5, 7));
        board.AddPiece(new PieceKnight(PieceColor.Black, 6, 7));
        board.AddPiece(new PieceRook(PieceColor.Black, 7, 7));

        //Black frontline
        for (var i = 0; i < 8; i++)
            board.AddPiece(new PiecePawn(PieceColor.Black, i, 6, Direction.Down));

        board.SetTurn(PieceColor.White);
        return board;
    }
}