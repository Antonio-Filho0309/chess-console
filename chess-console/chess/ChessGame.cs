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
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;
        public bool Xeque { get; private set; }

        public ChessGame()
        {
            Board = new Board(8,8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finish = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            placePiece();
            Xeque = false;
        }

        public Piece executeMovement(Position origin, Position destiny)
        {
            Piece p = Board.RemovePiece(origin);
            p.increaseMovement();
            Piece capturedPiece = Board.RemovePiece(destiny);
            Board.placePiece(p, destiny);
            if (capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void UndoMovement(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = Board.RemovePiece(destiny);
            p.decreaseMovement();
            if (capturedPiece != null)
            {
                Board.placePiece(capturedPiece, destiny);
                Captured.Remove(capturedPiece);
            }
            Board.placePiece(p, origin);
        }

        public void PlayTheGame(Position origin, Position destiny)
        {
           Piece capturedPiece = executeMovement(origin, destiny);

            if (IsInCheck(CurrentPlayer))
            {
                UndoMovement(origin,destiny,capturedPiece);

                throw new BoardException("Você não pode se colocar em xeque!");
            }

            if (IsInCheck(adversary(CurrentPlayer)))
            {
                Xeque = true;
            }else
            {
                Xeque = false;
            }

            if (TestXequeMate(adversary(CurrentPlayer)))
            {
                Finish = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }
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

        private Color adversary(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            return Color.White;
        }


        private Piece King(Color color)
        {
            foreach (Piece x in PiecesInTheGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece K = King(color);
            if(K == null)
            {
                throw new BoardException($"Não tem rei da cor {color} no tabuleiro");
            }

            foreach (Piece x in PiecesInTheGame(adversary(color)))
            {
                bool[,] mat = x.possibleMovements();
                if (mat[K.Position.Line, K.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool TestXequeMate(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }

            foreach (Piece x in PiecesInTheGame(color))
            {
                bool[,] mat = x.possibleMovements();
                for (int i=0; i<Board.Lines; i++)
                {
                    for (int j =0; j<Board.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.Position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = executeMovement(origin, new Position(i, j));
                            bool testXeque = IsInCheck(color);
                            UndoMovement(origin, destiny, capturedPiece);
                            if (!testXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void putNewPiece(char column,int line, Piece piece)
        {
            Board.placePiece(piece, new ChessPosition(column, line).toPosition());

            Pieces.Add(piece);
        }
        private void placePiece()
        {
            putNewPiece('c', 1, new Tower(Board, Color.White));
            putNewPiece('d', 1, new King(Board, Color.White));
            putNewPiece('h', 7, new Tower(Board, Color.White));
          
            
            putNewPiece('a', 8, new King(Board, Color.Black));
            putNewPiece('b', 8, new Tower(Board, Color.Black));
        }
    }
}
