using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Radioactive
{
    class RadioactiveMutantVampireBunnies
    {
        static void Main()
        {
            var num = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var matrix = new char[num[0], num[1]];

            var playerIndexes = new int[2];
            var bunniesIndexes = new List<int[]>();

            MatrixPusher(matrix, playerIndexes);

            var directionArray = Console.ReadLine().ToCharArray();

            bool isInside = true;
            bool StepOnBunny = false;

            int counter = 0;

            while (isInside && !StepOnBunny)
            {
                isInside = CheckIfInside(directionArray[counter], matrix, playerIndexes);

                if (isInside)
                {

                    BunniesIndexesSave(bunniesIndexes, matrix);
                    SpreadBunnies(bunniesIndexes, matrix);
                    StepOnBunny = CheckIfStepBunny(matrix, playerIndexes);

                }
                else
                {//won
                    BunniesIndexesSave(bunniesIndexes, matrix);
                    SpreadBunnies(bunniesIndexes, matrix);
                }
                bunniesIndexes.Clear();
                counter++;

            }
            Printer(matrix);
            if (!isInside)
            {
                Console.WriteLine($"won: {playerIndexes[0]} {playerIndexes[1]}");
            }
            else
            {
                Console.WriteLine($"dead: {playerIndexes[0]} {playerIndexes[1]}");
            }


        }

        private static void SpreadBunnies(List<int[]> bunniesIndexes, char[,] matrix)
        {
            foreach (var array in bunniesIndexes)
            {
                try
                {   //left
                    matrix[array[0], array[1] - 1] = 'B';
                }
                catch (Exception)
                {

                }
                try
                {   //right
                    matrix[array[0], array[1] + 1] = 'B';
                }
                catch (Exception)
                {

                }
                try
                {   //down
                    matrix[array[0] + 1, array[1]] = 'B';
                }
                catch (Exception)
                {

                }
                try
                {   //up
                    matrix[array[0] - 1, array[1]] = 'B';
                }
                catch (Exception)
                {

                }
            }
        }

        private static void BunniesIndexesSave(List<int[]> bunniesIndexes, char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        var array = new int[2];
                        array[0] = row;
                        array[1] = col;
                        bunniesIndexes.Add(array);
                    }
                }
            }
        }






        private static bool CheckIfStepBunny(char[,] matrix, int[] playerIndexes)
        {
            var playerRow = playerIndexes[0];
            var playerCol = playerIndexes[1];

            if (matrix[playerRow, playerCol] == 'B')
            {

                return true;
            }
            return false;
        }

        private static bool CheckIfInside(char direction, char[,] matrix, int[] playerIndexes)
        {
            if (direction == 'L')
            {
                var col = playerIndexes[1];
                if (col - 1 >= 0)
                {
                    matrix[playerIndexes[0], playerIndexes[1]] = '.';
                    playerIndexes[1]--;
                    return true;
                }
                else
                {
                    matrix[playerIndexes[0], playerIndexes[1]] = '.';
                    return false;
                }
            }
            else if (direction == 'R')
            {
                var col = playerIndexes[1];
                if (col + 1 <= matrix.GetLength(1) - 1)
                {
                    matrix[playerIndexes[0], playerIndexes[1]] = '.';
                    playerIndexes[1]++;
                    return true;
                }
                else
                {
                    matrix[playerIndexes[0], playerIndexes[1]] = '.';
                    return false;
                }
            }
            else if (direction == 'U')
            {
                var row = playerIndexes[0];
                if (row - 1 >= 0)
                {
                    matrix[playerIndexes[0], playerIndexes[1]] = '.';
                    playerIndexes[0]--;
                    return true;
                }
                else
                {
                    matrix[playerIndexes[0], playerIndexes[1]] = '.';
                    return false;
                }
            }
            else // 'D'
            {
                var row = playerIndexes[0];
                if (row + 1 <= matrix.GetLength(0) - 1)
                {
                    matrix[playerIndexes[0], playerIndexes[1]] = '.';
                    playerIndexes[0]++;
                    return true;
                }
                else
                {
                    matrix[playerIndexes[0], playerIndexes[1]] = '.';
                    return false;
                }
            }
        }

        private static void Printer(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{ matrix[row, col]}");

                }
                Console.WriteLine();
            }
        }

        private static void MatrixPusher(char[,] matrix, int[] playerIndexes)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'P')
                    {
                        playerIndexes[0] = row;
                        playerIndexes[1] = col;
                    }
                }
            }
        }
    }
}