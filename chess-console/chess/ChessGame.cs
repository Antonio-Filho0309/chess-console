using board;
using board.Exceptions;
using chess_console;


namespace chess
{
    class ChessGame
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer{ get; private set; }
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

        public void PlayTheGame(Position origin, Position destiny)
        {
            executeMovement(origin, destiny);
            Turn++;
            ChangePlayer();
        }

        public void ValidOriginPosition(Position pos)
        {
            if (Board.piece(pos) == null)
            {
                throw new BoardException("Não existe peça na posição de origem escolhida");
            } else if (CurrentPlayer != Board.piece(pos).Color)
            {
                throw new BoardException("A peça de origem escolhida não é sua");
            } else if (!Board.piece(pos).HavePossibleMovement())
            {
                throw new BoardException("Não há movimentos possíveis para a peça de origem escolhida");
            }
        }

        public void ValidDestinyPosition(Position origin, Position destiny)
        {
            if (!Board.piece(origin).CanMoveTo(destiny))
            {
                throw new BoardException("Posição de destino inválida");
            }
        }

        private void ChangePlayer()
        {
            if(CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            } else
            {
                CurrentPlayer = Color.White;
            }
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
