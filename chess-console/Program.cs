using board;
using chess;
using System;

namespace chess_console
{
    class Program
    {
        public  static void Main(string[] args)
        {
            Board board = new Board(8,8);

            board.placePeace(new Tower(board,Color.Black), new Position(0, 0));
            board.placePeace(new Tower(board, Color.Black), new Position(1, 3));
            board.placePeace(new King(board, Color.Black), new Position(2, 4));

            Screen.printBoard(board);
            Console.ReadLine();
        }
    }

}
