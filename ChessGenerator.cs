internal static class ChessGenerator
{
    public static ChessBoard Classic()
    {
        const int BOARD_WIDTH = 8;
        const int BOARD_HEIGHT = 8;

        var board = new ChessBoard(BOARD_WIDTH, BOARD_HEIGHT);

        //White backline
        board.SetPiece<PieceKnight>(PieceColor.White, 0, 0);
        board.SetPiece<PieceRook>(PieceColor.White, 1, 0);
        board.SetPiece<PieceBishop>(PieceColor.White, 2, 0);
        board.SetPiece<PieceQueen>(PieceColor.White, 3, 0);
        board.SetPiece<PieceKing>(PieceColor.White, 4, 0);
        board.SetPiece<PieceBishop>(PieceColor.White, 5, 0);
        board.SetPiece<PieceKnight>(PieceColor.White, 6, 0);
        board.SetPiece<PieceRook>(PieceColor.White, 7, 0);

        //White frontline
        for (var i = 0; i < 8; i++)
            board.SetPiece<PiecePawn>(PieceColor.White, i, 1);

        //Black backline
        board.SetPiece<PieceKnight>(PieceColor.White, 0, 7);
        board.SetPiece<PieceRook>(PieceColor.White, 1, 7);
        board.SetPiece<PieceBishop>(PieceColor.White, 2, 7);
        board.SetPiece<PieceQueen>(PieceColor.White, 3, 7);
        board.SetPiece<PieceKing>(PieceColor.White, 4, 7);
        board.SetPiece<PieceBishop>(PieceColor.White, 5, 7);
        board.SetPiece<PieceKnight>(PieceColor.White, 6, 7);
        board.SetPiece<PieceRook>(PieceColor.White, 7, 7);

        //Black frontline
        for (var i = 0; i < 8; i++)
            board.SetPiece<PiecePawn>(PieceColor.White, i, 6);

        board.SetTurn(PieceColor.White);
        return board;
    }

    public static ChessBoard Test()
    {
        const int BOARD_WIDTH = 8;
        const int BOARD_HEIGHT = 8;

        var board = new ChessBoard(BOARD_WIDTH, BOARD_HEIGHT);

        //White backline
        board.SetPiece<PieceBishop>(PieceColor.White, 3, 2);
        board.SetPiece<PieceBishop>(PieceColor.Black, 2, 1);

        board.SetTurn(PieceColor.White);
        return board;
    }
}