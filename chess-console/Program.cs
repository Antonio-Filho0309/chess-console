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

                board.placePeace(new Tower(board, Color.Black), new Position(0, 0));
                board.placePeace(new King(board, Color.Black), new Position(0, 2));

                board.placePeace(new Tower(board, Color.Black), new Position(1, 3));
                board.placePeace(new King(board, Color.Black), new Position(2, 4));

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
