﻿using board;
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
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;

        public ChessGame()
        {
            Board = new Board(8,8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finish = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            placePiece();
        }

        public void executeMovement(Position origin, Position destiny)
        {
            Piece p = Board.RemovePiece(origin);
            p.increaseMovement();
            Piece capturedPiece = Board.RemovePiece(destiny);
            Board.placePiece(p, destiny);
            if (capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
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

        public HashSet<Piece> capturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Captured)
            {
                if(x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInTheGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }

        public void putNewPiece(char column,int line, Piece piece)
        {
            Board.placePiece(piece, new ChessPosition(column, line).toPosition());

            Pieces.Add(piece);
        }
        private void placePiece()
        {
            putNewPiece('c', 1, new Tower(Board, Color.White));
            putNewPiece('c', 2, new Tower(Board, Color.White));
            putNewPiece('d', 2, new Tower(Board, Color.White));
            putNewPiece('e', 2, new Tower(Board, Color.White));
            putNewPiece('e', 1, new Tower(Board, Color.White));
            putNewPiece('d', 1, new King(Board, Color.White));


            putNewPiece('c', 7, new Tower(Board, Color.Black));
            putNewPiece('c', 8, new Tower(Board, Color.Black));
           putNewPiece('d', 7, new Tower(Board, Color.Black));
            putNewPiece('e', 7, new Tower(Board, Color.Black));
            putNewPiece('e', 8, new Tower(Board, Color.Black));
            putNewPiece('d', 8, new King(Board, Color.Black));
        }
    }
}
