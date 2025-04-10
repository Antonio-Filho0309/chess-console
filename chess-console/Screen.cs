using board;
using chess;
namespace chess_console
{
    class Screen
    {
        public static void printGame(ChessGame game)
        {
            printBoard(game.Board);
            Console.WriteLine();
            printCapturedPieces(game);
            Console.WriteLine();
            Console.WriteLine($"Turno: {game.Turn}");

            if (!game.Finish)
            {
                Console.WriteLine($"Aguardando jogada: {game.CurrentPlayer}");

                if (game.Xeque)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine($"Vencedor: " + game.CurrentPlayer);
            }


        }

        public static void printCapturedPieces(ChessGame game)
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas:");
            PrintJoint(game.capturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Pretas:");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintJoint(game.capturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void PrintJoint(HashSet<Piece> joint)
        {
            Console.Write("[");
            foreach (Piece x in joint)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }
        public static void printBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    printPiece(board.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printBoard(Board board, bool[,] mat)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor alteredBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        Console.BackgroundColor = alteredBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    printPiece(board.piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");     
            Console.BackgroundColor = originalBackground;
        }

        public static ChessPosition ReadPositionChess()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }
        public static void printPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {


                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }

        }

    }
}
