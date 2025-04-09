using board;
namespace chess.Pieces
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {
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

            // Acima 
            pos.setValues(Position.Line - 1, Position.Column);
            while (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line--;
            }

            // Abaixo
            pos.setValues(Position.Line + 1, Position.Column);
            while (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line++;
            }

            // Direita
            pos.setValues(Position.Line, Position.Column + 1);
            while (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column++;
            }

            // Esquerda
            pos.setValues(Position.Line, Position.Column - 1);
            while (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column--;
            }

            //NO
            pos.setValues(Position.Line - 1, Position.Column - 1);
            while (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Line - 1, pos.Column - 1);
            }

            //NE
            pos.setValues(Position.Line - 1, Position.Column + 1);
            while (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Line - 1, pos.Column + 1);
            }

            //SE
            pos.setValues(Position.Line + 1, Position.Column + 1);
            while (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Line + 1, pos.Column + 1);
            }

            //SO
            pos.setValues(Position.Line + 1, Position.Column - 1);
            while (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Line + 1, pos.Column - 1);
            }
            return mat;
        }

        public override string ToString()
        {
            return "Q";
        }
    }
}
