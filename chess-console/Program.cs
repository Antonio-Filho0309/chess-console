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
            ChessPosition pos = new ChessPosition('c', 7);
            Console.WriteLine(pos);
            Console.WriteLine(pos.toPosition());
            Console.ReadLine();
        }
    }

}
