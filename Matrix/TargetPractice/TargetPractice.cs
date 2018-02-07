using System;
using System.Linq;

namespace TargetPractice
{
    class TargetPractice
    {
        static void Main()
        {
            var matrixInd = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var matrix = new char[matrixInd[0], matrixInd[1]];

            string snake = Console.ReadLine();

            var commands = Console.ReadLine().Split();
            //array filled
            ArrayPusher(matrix, snake);

            Shoot(matrix, commands);

            FindEmpty(matrix);

            PrintMe(matrix);

        }

        private static void PrintMe(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int zi = 0; zi < matrix.GetLength(1); zi++)
                {
                    Console.Write(matrix[i, zi]);
                }
                Console.WriteLine();

            }
        }

        private static void FindEmpty(char[,] matrix)
        {
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == ' ')
                    {
                        DropDown(matrix, col, row);
                    }
                }
            }
        }

        private static void DropDown(char[,] matrix, int col, int row)
        {
            for (int rows = row - 1; rows >= 0; rows--)
            {
                if (matrix[rows, col] != ' ')
                {
                    matrix[row, col] = matrix[rows, col];
                    matrix[rows, col] = ' ';
                    row--;
                }
            }
        }



        private static void Shoot(char[,] matrix, string[] commands)
        {

            var rowLand = int.Parse(commands[0]);
            var colLand = int.Parse(commands[1]);
            int splash = int.Parse(commands[2]);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {

                    double rowSum = Math.Pow(row - rowLand, 2);

                    double colSum = Math.Pow(col - colLand, 2);

                    if (rowSum + colSum <= Math.Pow(splash, 2))
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }


        }

        private static void ArrayPusher(char[,] matrix, string snake)
        {
            int counter = 0;

            int snakeIndex = 0;

            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                if (counter % 2 == 0)
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[snakeIndex];
                        snakeIndex++;
                        if (snakeIndex == snake.Length) snakeIndex = 0;
                    }
                    counter++;
                }
                else if (counter % 2 == 1)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snake[snakeIndex];
                        snakeIndex++;
                        if (snakeIndex == snake.Length) snakeIndex = 0;
                    }
                    counter++;
                }
            }
        }
    }
}