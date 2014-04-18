using System;
using System.Collections.Generic;

namespace EightQueens
{
    class Program
    {
        const int n = 8;

        static int[,] board = new int[n, n];
        static int QueenCount = 0;
        static bool[] TakenRows = new bool[n];
        static int CurrentSolution = 1;

        static void Main()
        {
            FindQueens(0, 0);
        }

        private static void FindQueens(int row, int col)
        {
            for (int r = row; r < board.GetLength(0) && col < board.GetLength(1); r++)
            {
                if (IsOpen(r, col))
                {
                    board[r, col] = 1;
                    QueenCount++;
                    TakenRows[r] = true;
                    if (QueenCount == n)
                    {
                        PrintBoard();
                    }
                    else
                    {
                        FindQueens(0, col + 1);
                    }
                    board[r, col] = 0;
                    QueenCount--;
                    TakenRows[r] = false;
                }
            }
        }

        private static void PrintBoard()
        {
            Console.WriteLine(CurrentSolution + ".");
            CurrentSolution++;
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write("{0, 2}", board[row, col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static bool IsOpen(int row, int col)
        {
            for (int r = row - 1, c = col - 1; r >= 0 && c >= 0; r--, c--)
            {
                if (board[r, c] == 1)
                {
                    return false;
                }
            }
            for (int r = row + 1, c = col - 1; r < board.GetLength(0) && c >= 0; r++, c--)
            {
                if (board[r, c] == 1)
                {
                    return false;
                }
            }
            if (TakenRows[row])
            {
                return false;
            }
            return true;
        }
    }
}
