using System;
using System.Numerics;

namespace EightQueens
{
    class Program
    {
        static char[,] map;
        static BigInteger pathCount = 0;

        static void Main()
        {
            ReadInput();
            FindExit(0, 0);
            Console.WriteLine(pathCount);
        }

        private static void ReadInput()
        {
            string[] coords = Console.ReadLine().Split(' ');
            int n = int.Parse(coords[0]);
            int m = int.Parse(coords[1]);
            map = new char[n, m];

            string[] food = Console.ReadLine().Split(' ');
            int foodX = int.Parse(food[0]);
            int foodY = int.Parse(food[1]);
            map[foodX, foodY] = 'f';
            map[0, 0] = 'd';

            int k = int.Parse(Console.ReadLine());
            for (int i = 0; i < k; i++)
            {
                string[] enemy = Console.ReadLine().Split(' ');
                int enemyX = int.Parse(enemy[0]);
                int enemyY = int.Parse(enemy[1]);
                map[enemyX, enemyY] = 'e';
            }
        }

        private static void FindExit(int row, int col)
        {
            if (row >= map.GetLength(0) || col >= map.GetLength(1) || map[row, col] == 'e')
            {
                return;
            }
            else if (map[row, col] == 'f')
            {
                pathCount++;
                return;
            }
            FindExit(row + 1, col);
            FindExit(row, col + 1);
        }
    }
}
