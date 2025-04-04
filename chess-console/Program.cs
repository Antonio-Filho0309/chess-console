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
                ChessGame game = new ChessGame();

                while (!game.Finish)
                {
                    try
                    {
                        Console.Clear();
                        Screen.printBoard(game.Board);
                        Console.WriteLine();
                        Console.WriteLine($"Turno: {game.Turn}");
                        Console.WriteLine($"Aguardando jogada: {game.CurrentPlayer}");

                        Console.WriteLine();
                        Console.WriteLine("Origem: ");
                        Position origin = Screen.ReadPositionChess().toPosition();
                        game.ValidOriginPosition(origin);

                        bool[,] possiblePosition = game.Board.piece(origin).possibleMovements();

                        Console.Clear();
                        Screen.printBoard(game.Board, possiblePosition);

                        Console.WriteLine();
                        Console.WriteLine("Destino: ");
                        Position destiny = Screen.ReadPositionChess().toPosition();
                        game.ValidDestinyPosition(origin, destiny);

                        game.PlayTheGame(origin, destiny);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(e.Message +"!");
                        Console.Write("\nPressione tecla ENTER para continuar:");
                        Console.ReadLine();
                    }

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
