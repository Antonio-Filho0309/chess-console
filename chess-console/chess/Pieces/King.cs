using board;
namespace chess.Pieces
{
    class King : Piece
    {
        public King(Board board, Color color): base(board, color) 
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

            //acima
            pos.setValues(Position.Line - 1, Position.Column);
            if(Board.PositionIsValid(pos) && canMove(pos))
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
            pos.setValues(Position.Line, Position.Column+ 1);
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
            pos.setValues(Position.Line, Position.Column -1);
            if (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //noroeste
            pos.setValues(Position.Line - 1, Position.Column -1);
            if (Board.PositionIsValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;

        }

        public override string ToString()
        {
            return "K";
        }
    }
}
