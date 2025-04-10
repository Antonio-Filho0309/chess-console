using board;

namespace chess.Pieces
{
    class Pawn : Piece
    {
        private ChessGame Game;

        public Pawn(Board board, Color color, ChessGame game) : base(board, color)
        {
            Game = game;
        }

        private bool HaveEnemy(Position pos)
        {
            Piece p = Board.piece(pos);
            return p != null && p.Color != Color;
        }

        private bool Free(Position pos)
        {
            return Board.piece(pos) == null;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                // Movimento normal para frente
                pos.setValues(Position.Line - 1, Position.Column);
                if (Board.PositionIsValid(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // Primeiro movimento: duas casas
                pos.setValues(Position.Line - 2, Position.Column);
                Position intermediate = new Position(Position.Line - 1, Position.Column);
                if (Board.PositionIsValid(pos) && Free(pos) && Free(intermediate) && AmountMovements == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // Captura na diagonal esquerda
                pos.setValues(Position.Line - 1, Position.Column - 1);
                if (Board.PositionIsValid(pos) && HaveEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // Captura na diagonal direita
                pos.setValues(Position.Line - 1, Position.Column + 1);
                if (Board.PositionIsValid(pos) && HaveEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // Jogada especial: en passant
                if (Position.Line == 3)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.PositionIsValid(left) && Board.piece(left) == Game.vulnerableInPassant)
                    {
                        mat[left.Line - 1, left.Column] = true;
                    }

                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (Board.PositionIsValid(right) && Board.piece(right) == Game.vulnerableInPassant)
                    {
                        mat[right.Line - 1, right.Column] = true;
                    }
                }
            }
            else
            {
                // Movimento normal para frente
                pos.setValues(Position.Line + 1, Position.Column);
                if (Board.PositionIsValid(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // Primeiro movimento: duas casas
                pos.setValues(Position.Line + 2, Position.Column);
                Position intermediate = new Position(Position.Line + 1, Position.Column);
                if (Board.PositionIsValid(pos) && Free(pos) && Free(intermediate) && AmountMovements == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // Captura na diagonal esquerda
                pos.setValues(Position.Line + 1, Position.Column - 1);
                if (Board.PositionIsValid(pos) && HaveEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // Captura na diagonal direita
                pos.setValues(Position.Line + 1, Position.Column + 1);
                if (Board.PositionIsValid(pos) && HaveEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // Jogada especial: en passant
                if (Position.Line == 4)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.PositionIsValid(left) && Board.piece(left) == Game.vulnerableInPassant)
                    {
                        mat[left.Line + 1, left.Column] = true;
                    }

                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (Board.PositionIsValid(right) && Board.piece(right) == Game.vulnerableInPassant)
                    {
                        mat[right.Line + 1, right.Column] = true;
                    }
                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
