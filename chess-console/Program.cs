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
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                ChessGame game = new ChessGame();
                Screen.printBoard(game.Board);

                while (!game.Finish)
                {
                    Console.Clear();
                    Screen.printBoard(game.Board);
                    Console.WriteLine();
                    Console.WriteLine("Origem: ");
                    Position origin = Screen.ReadPositionChess().toPosition();
                    Console.WriteLine("Destino: ");
                    Position destiny = Screen.ReadPositionChess().toPosition();


                    game.executeMovement(origin, destiny);

                }

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }

}
