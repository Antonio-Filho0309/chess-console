using board;
namespace chess.Pieces
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
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

            //NO
            pos.setValues(Position.Line - 1, Position.Column - 1);
            while(Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(Board.piece(pos) != null && Board.piece(pos).Color != Color)
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
            return "B";
        }
    }
}
