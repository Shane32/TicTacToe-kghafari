using System;
using System.Threading;

namespace ZBOX_TicTacToe
{
    class Program
    {
        static char[] board = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; //0 is unused
        static int winFlag = 0; // -1 = draw, 1 = win for player n
        static int turn = 1;
        static char p1Symbol = 'X';
        static char p2Symbol = 'O';
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine($"Player 1: {p1Symbol}, Player 2: {p2Symbol}");

                //determine turn
                if (turn % 2 == 0)
                {
                    Console.WriteLine("Player 2's turn");
                }
                else
                {
                    Console.WriteLine("Player 1's turn");
                }
                Console.WriteLine("\n");
                DrawBoard();

                //get input
                int choice = int.Parse(Console.ReadLine());

                if (board[choice] != p1Symbol && board[choice] != p2Symbol)
                { //board position not occupied
                    if (turn % 2 == 0)
                    {
                        board[choice] = p2Symbol;
                        turn++;
                    }
                    else
                    {
                        board[choice] = p1Symbol;
                        turn++;
                    }
                }
                else
                {
                    //error, board position already occupied
                    Console.WriteLine("Board position already filled");
                    Console.WriteLine("Reloading board...");
                    Thread.Sleep(2500);
                }

                CheckWin();
            }
            while (winFlag != -1 && winFlag != 1);

            if (winFlag == 1)
            {
                Console.Clear();
                Console.WriteLine($"Player {(turn % 2) + 1} wins!");
                Console.WriteLine("\n");
                DrawBoard();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Draw!");
                Console.WriteLine("\n");
                DrawBoard();
            }
            Console.ReadLine();

            //evaluate win/draw
        }

        static void DrawBoard()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[1], board[2], board[3]);
            Console.WriteLine("_____|_____|____");

            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[4], board[5], board[6]);
            Console.WriteLine("_____|_____|____");

            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[7], board[8], board[9]);
            Console.WriteLine("     |     |     ");

        }

        static void CheckWin()
        {
            //horizontal
            if (board[1] == board[2] && board[2] == board[3])
            {
                winFlag = 1;
            }
            else if (board[4] == board[5] && board[5] == board[6])
            {
                winFlag = 1;
            }
            else if (board[7] == board[8] && board[8] == board[9])
            {
                winFlag = 1;
            }
            //vertical
            else if (board[1] == board[4] && board[4] == board[7])
            {
                winFlag = 1;
            }
            else if (board[2] == board[5] && board[5] == board[8])
            {
                winFlag = 1;
            }
            else if (board[3] == board[6] && board[6] == board[9])
            {
                winFlag = 1;
            }
            //diagonal
            else if (board[1] == board[5] && board[5] == board[9])
            {
                winFlag = 1;
            }
            else if (board[3] == board[5] && board[5] == board[7])
            {
                winFlag = 1;
            }
            //draw
            else if (turn > 9)
            {
                winFlag = -1;
            }
            else
            {
                winFlag = 0;
            }
        }
    }
}
