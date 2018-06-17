using System;

namespace A07_TicTacToe
{
    class TicTacToe
    {
        private static char[] GameData = new char[9] {'1','2','3','4','5','6','7','8','9'};
        private static int[,] WinCases = new int[8,3] {
            {0,1,2},
            {3,4,5},
            {6,7,8},
            {0,3,6},
            {1,4,7},
            {2,5,8},
            {0,4,8},
            {2,4,6}
        };
        private static int TurnCount = 0;
        private static char TurnPlayer = 'X';
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TicTacToe!");
            bool running = true;
            while (running)
            {
                running = Turn();
            }
            PrintPlayfield();
            Console.WriteLine("See you soon!");
        }
        private static bool Turn()
        {
            Console.WriteLine($":: It's player {TurnPlayer}'s turn ::");
            PrintPlayfield();
            Console.WriteLine("Please enter a field number (see field above): ");
            string rawInput = Console.ReadLine();
            int input;
            bool validInput = int.TryParse(rawInput, out input);
            if (!validInput || input <= 0 || input >= 10)
            {
                Console.WriteLine("Please enter a valid number.");
                return true;
            }
            else if (!CheckField(input - 1))
            {
                Console.WriteLine("Field already filled. Please choose another field.");
                return true;
            }
            else
            {
                GameData[input - 1] = TurnPlayer;
                TurnCount++;
                if (CheckWin())
                {
                    Console.WriteLine($"Player {TurnPlayer} has won!");
                    return false;
                }
                else if (TurnCount == 9)
                {
                    Console.WriteLine("Draw! How could this happen?");
                    return false;
                }
                else
                {
                    TurnPlayer = (TurnPlayer == 'X') ? 'O' : 'X';
                    return true;
                }
            }
        }
        private static bool CheckField(int index)
        {
            return GameData[index] != 'X' && GameData[index] != 'O';
        }
        private static bool CheckWin()
        {
            for (int i = 0; i < WinCases.GetLength(0); i++)
            {
                if (GameData[WinCases[i,0]] == GameData[WinCases[i,1]] && GameData[WinCases[i,0]] == GameData[WinCases[i,2]])
                {
                    return true;
                }
            }
            return false;
        }

        private static void PrintPlayfield()
        {
            Console.WriteLine( "┌───┬───┬───┐");
            Console.WriteLine($"| {GameData[0]} | {GameData[1]} | {GameData[2]} |");
            Console.WriteLine( "├───┼───┼───┤");
            Console.WriteLine($"| {GameData[3]} | {GameData[4]} | {GameData[5]} |");
            Console.WriteLine( "├───┼───┼───┤");
            Console.WriteLine($"| {GameData[6]} | {GameData[7]} | {GameData[8]} |");
            Console.WriteLine( "└───┴───┴───┘");
        }
    }
}
