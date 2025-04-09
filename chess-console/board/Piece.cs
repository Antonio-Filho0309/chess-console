using board;

namespace board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int AmountMovements { get; set; }
        public Board Board { get; protected set; }
        
        public Piece(Board board, Color color)
        {
            Position = null;
            Color = color;
            Board = board;
            AmountMovements = 0;
        }

        public abstract bool[,] possibleMovements();

        public bool HavePossibleMovement()
        {
            bool[,] mat = possibleMovements();
            for(int i=0; i<Board.Lines; i++)
            {
                for(int j=0; j<Board.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PossibleMovement(Position pos)
        {
            return possibleMovements()[pos.Line, pos.Column];
        }

        public void increaseMovement()
        {
            AmountMovements++;
        }

        public void decreaseMovement()
        {
            AmountMovements--;
        }
    }
}
