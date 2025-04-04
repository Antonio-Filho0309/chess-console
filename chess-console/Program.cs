using board;
using board.Exceptions;
using chess;
using System;

namespace chess_console
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);

                board.placePiece(new Tower(board, Color.Black), new Position(0, 0));

                board.placePiece(new Tower(board, Color.Black), new Position(1, 3));

                board.placePiece(new King(board, Color.White), new Position(2, 4));

                board.placePiece(new King(board, Color.White), new Position(3, 5));

                Screen.printBoard(board);

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }

}
