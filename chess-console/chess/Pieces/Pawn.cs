using board;
using System.Reflection.PortableExecutable;
namespace chess.Pieces
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {
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

        private bool canMove(Position pos)
        {
            if (!Board.PositionIsValid(pos))
            {
                return false;
            }
            Piece p = Board.piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.setValues(Position.Line - 1, Position.Column);
                if (Board.PositionIsValid(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setValues(Position.Line -2, Position.Column);
                if(Board.PositionIsValid(pos) && Free(pos) && AmountMovements ==0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setValues(Position.Line - 1, Position.Column - 1);
                if(Board.PositionIsValid(pos) && HaveEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setValues(Position.Line - 1, Position.Column + 1);
                if (Board.PositionIsValid(pos) && HaveEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }
            else
            {
                pos.setValues(Position.Line + 1, Position.Column);
                if (Board.PositionIsValid(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setValues(Position.Line + 2, Position.Column);
                if (Board.PositionIsValid(pos) && Free(pos) && AmountMovements == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setValues(Position.Line + 1, Position.Column - 1);
                if (Board.PositionIsValid(pos) && HaveEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setValues(Position.Line + 1, Position.Column + 1);
                if (Board.PositionIsValid(pos) && HaveEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
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
