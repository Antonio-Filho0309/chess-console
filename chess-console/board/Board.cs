using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using board.Exceptions;

namespace board
{
    class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public Board()
        {
        }

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines,columns];
        }

        public Piece piece(int line, int column)
        {
            return Pieces[line, column];
        }

        public Piece piece(Position pos)
        {
            return Pieces[pos.Line, pos.Column];
        }
        public void placePeace(Piece p, Position pos)
        {
            if(HavePiece(pos))
            {
                throw new BoardException("Já existe uma peça nessa posição");
            }
            Pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }


        public bool HavePiece(Position pos)
        {
            validPosition(pos);
            return piece(pos) != null;
        }

        public bool PositionIsValid(Position pos)
        {
            if(pos.Line<0 || pos.Line>=Lines || pos.Column<0 || pos.Column >= Columns)
            {
                return false;
            }
            return true;
        }


        public void validPosition(Position pos)
        {
            if (!PositionIsValid(pos))
            {
                throw new BoardException("Posição inválida!");
            }
        }
    }
}
