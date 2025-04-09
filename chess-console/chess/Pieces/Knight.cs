using board;
namespace chess.Pieces
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
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


            pos.setValues(Position.Line - 1, Position.Column - 2);
            if (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.setValues(Position.Line - 2, Position.Column - 1);
            if (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.setValues(Position.Line - 2, Position.Column + 1);
            if (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            
            pos.setValues(Position.Line - 1, Position.Column + 2);
            if (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            
            pos.setValues(Position.Line + 1, Position.Column + 2);
            if (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
           
            pos.setValues(Position.Line + 2, Position.Column + 1);
            if (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

           
            pos.setValues(Position.Line + 2, Position.Column - 1);
            if (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //noroeste
            pos.setValues(Position.Line + 1, Position.Column - 2);
            if (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }

        public override string ToString()
        {
            return "H";
        }
    }
}
