using board;
namespace chess.Pieces
{
    class King : Piece
    {
        private ChessGame Game;
        public King(Board board, Color color, ChessGame game) : base(board, color)
        {
            Game = game;
        }

        private bool canMove(Position pos)
        {
            if (!Board.PositionIsValid(pos))
            {
                return false;
            }
            Piece p = Board.piece(pos);
            return p == null || p.Color != Color;
        }

        private bool testTowerToRoque(Position pos)
        {
            Piece p = Board.piece(pos);
            return p != null && p is Tower && p.Color == Color && p.AmountMovements == 0;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            //acima
            pos.setValues(Position.Line - 1, Position.Column);
            if (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //nordeste
            pos.setValues(Position.Line - 1, Position.Column + 1);
            if (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //direita
            pos.setValues(Position.Line, Position.Column + 1);
            if (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //sudeste
            pos.setValues(Position.Line + 1, Position.Column + 1);
            if (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //abaixo
            pos.setValues(Position.Line + 1, Position.Column);
            if (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //sudoeste
            pos.setValues(Position.Line + 1, Position.Column - 1);
            if (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //esquerda
            pos.setValues(Position.Line, Position.Column - 1);
            if (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //noroeste
            pos.setValues(Position.Line - 1, Position.Column - 1);
            if (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // #JogadaEspecial roque
            if (AmountMovements == 0 && !Game.Xeque)
            {
                // #jogadaespecial roque pequeno
                Position posT1 = new Position(Position.Line, Position.Column + 3);
                if (testTowerToRoque(posT1))
                {
                    Position p1 = new Position(Position.Line, Position.Column + 1);
                    Position p2 = new Position(Position.Line, Position.Column + 2);
                    if (Board.piece(p1) == null && Board.piece(p2) == null)
                    {
                        mat[Position.Line, Position.Column + 2] = true;
                    }
                }

                // #jogadaespecial roque grande
                Position posT2 = new Position(Position.Line, Position.Column - 4);
                if (testTowerToRoque(posT2))
                {
                    Position p1 = new Position(Position.Line, Position.Column - 1);
                    Position p2 = new Position(Position.Line, Position.Column - 2);
                    Position p3 = new Position(Position.Line, Position.Column - 3);
                    if (Board.piece(p1) == null && Board.piece(p2) == null && Board.piece(p3) == null)
                    {
                        mat[Position.Line, Position.Column - 2] = true;
                    }
                }
            }

            return mat;

        }

        public override string ToString()
        {
            return "K";
        }
    }
}
