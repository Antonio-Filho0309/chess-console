using board;

namespace board
{
    class Piece
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
    }
}
