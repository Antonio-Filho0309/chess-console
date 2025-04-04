using board;
using chess_console;


namespace chess
{
    class ChessGame
    {
        public Board Board { get; private set; }
        private int Turn;
        private Color CurrentPlayer;
        public bool Finish { get; private set; }

        public ChessGame()
        {
            Board = new Board(8,8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finish = false;
            placePiece();
        }

        public void executeMovement(Position origin, Position destiny)
        {
            Piece p = Board.RemovePiece(origin);
            p.increaseMovement();
            Piece CapturedPiece = Board.RemovePiece(destiny);
            Board.placePiece(p, destiny);
        }

        private void placePiece()
        {
            Board.placePiece(new Tower(Board, Color.White), new ChessPosition('c', 1).toPosition());
            Board.placePiece(new Tower(Board, Color.White), new ChessPosition('c', 2).toPosition());
            Board.placePiece(new Tower(Board, Color.White), new ChessPosition('d', 2).toPosition());
            Board.placePiece(new Tower(Board, Color.White), new ChessPosition('e', 1).toPosition());
            Board.placePiece(new Tower(Board, Color.White), new ChessPosition('e', 2).toPosition());
            Board.placePiece(new King(Board, Color.White), new ChessPosition('d', 1).toPosition());


            Board.placePiece(new Tower(Board, Color.Black), new ChessPosition('c', 7).toPosition());
            Board.placePiece(new Tower(Board, Color.Black), new ChessPosition('c', 8).toPosition());
            Board.placePiece(new Tower(Board, Color.Black), new ChessPosition('d', 7).toPosition());
            Board.placePiece(new Tower(Board, Color.Black), new ChessPosition('e', 7).toPosition());
            Board.placePiece(new Tower(Board, Color.Black), new ChessPosition('e', 8).toPosition());
            Board.placePiece(new King(Board, Color.Black), new ChessPosition('d', 8).toPosition());


        }
    }
}
