using System;
using System.Numerics;

namespace TicTacToe
{
    class Program
    {
        static char[] pos = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char Player = 'X';
        static int steps = 0;
        static bool gameActive = true;

        //      == >> MENU << ==
        static void DisplayMenu()
        {
            Console.Clear();
            Console.Write(@"======================================
::  Welcome, User!, it's TTT game.  ::
::  Do u wonna start?               ::
======================================
::  1) Yes                          ::
::  2) No ( Exit program )          ::
======================================");
            Console.Write("\nYour choice: ");
        }

        //      == >> BOARD << ==
        static void DrawBoard()
        {
            Console.Clear();
            Console.Write(@$"Player - {Player}

 {pos[0]} | {pos[1]} | {pos[2]}
-----------
 {pos[3]} | {pos[4]} | {pos[5]}
-----------
 {pos[6]} | {pos[7]} | {pos[8]}
");
        }

        //      == >> PLAYER MOVE << ==
        static void GetPlayerMove()
        {
            bool validMove = false;
            while (!validMove && gameActive)
            {
                Console.Write($"\nPlayer {Player}, choose a position (1-9): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int position) && position >= 1 && position <= 9)
                {
                    int index = position - 1;

                    if (pos[index] != 'X' && pos[index] != 'O')
                    {
                        pos[index] = Player;
                        steps++;
                        validMove = true;
                    }
                    else
                    {
                        Console.WriteLine("Position already taken! Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a number 1-9.");
                }
            }
        }

        //      == >> CHECK WINNER << ==
        static bool CheckWinner()
        {
            // rows
            for (int i = 0; i < 9; i += 3)
            {
                if (pos[i] == pos[i + 1] && pos[i + 1] == pos[i + 2])
                    return true;
            }

            // columns
            for (int i = 0; i < 3; i++)
            {
                if (pos[i] == pos[i + 3] && pos[i + 3] == pos[i + 6])
                    return true;
            }

            // diagonals
            if (pos[0] == pos[4] && pos[4] == pos[8])
                return true;
            if (pos[2] == pos[4] && pos[4] == pos[6])
                return true;

            return false;
        }

        //      == >> SWITCH PLAYER << ==
        static void SwitchPlayer()
        {
            Player = (Player == 'X') ? 'O' : 'X';
        }

        //      == >> CHECK FOR DRAW << ==
        static bool CheckDraw()
        {
            return steps >= 9;
        }

        //      == >> RESET GAME << ==
        static void ResetGame()
        {
            for (int i = 0; i < 9; i++)
            {
                pos[i] = (char)('1' + i);
            }
            Player = 'X';
            steps = 0;
            gameActive = true;
        }

        //      == >> DISPLAY RESULT << ==
        static void DisplayResult(bool isWin)
        {
            if (isWin)
            {
                Console.WriteLine($"\nPlayer {Player} win!");
            }
            else
            {
                Console.WriteLine("\nIt's a draw!");
            }

            Console.Write("\nPlay again? (Y/N): ");
            string choice = Console.ReadLine().ToUpper();

            if (choice == "Y")
            {
                ResetGame();
            }
            else
            {
                gameActive = false;
            }
        }

        //      == >> GAME << ==
        static void Game()
        {
            while (gameActive)
            {
                DrawBoard();
                GetPlayerMove();

                if (CheckWinner())
                {
                    DrawBoard();
                    DisplayResult(true);
                }
                else if (CheckDraw())
                {
                    DrawBoard();
                    DisplayResult(false);
                }
                else
                {
                    SwitchPlayer();
                }
            }
        }

        //      == >> MAIN << ==
        static void Main()
        {
            Console.Clear();
            DisplayMenu();
            string userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                Game();
            }
            else if (userChoice == "2")
            {
                Console.Clear();
                Console.WriteLine("Goodbye :(\nPress any key to continue . . .");
                Console.ReadKey();
                return;
            }
            else
            {
                Main();
            }
        }
    }
}