using board;

namespace chess.Pieces
{
    class Tower : Piece
    {
        public Tower(Board board, Color color) : base(board, color)
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

            return mat;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}

