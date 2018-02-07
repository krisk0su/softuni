using System;
using System.Linq;
namespace LegoBlocks
{
    class LegoBlocks
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            var jagged1 = CreateJagged(num);
            var jagged2 = CreateJagged(num);

            bool IfMatrix = CheckIfMatrix(jagged1, jagged2);

            if (IfMatrix)
            {
                //reverse the sec jagged
                ReverseSecond(jagged2);
                //print it
                PrintMatrix(jagged1, jagged2);
            }
            else
            {
                //print the elements
                PrintMethod(jagged1, jagged2);
            }
        }

        private static void PrintMatrix(int[][] jagged1, int[][] jagged2)
        {
            for (int row = 0; row < jagged2.GetLength(0); row++)
            {
                Console.Write($"[{string.Join(", ", jagged1[row])}");
                Console.Write(", ");
                Console.Write($"{string.Join(", ", jagged2[row])}]");
                Console.WriteLine();
            }
        }

        private static void ReverseSecond(int[][] jagged2)
        {
            for (int row = 0; row < jagged2.GetLength(0); row++)
            {
                jagged2[row] = jagged2[row].Reverse().ToArray();

            }
        }

        private static void PrintMethod(int[][] jagged1, int[][] jagged2)
        {
            var first = 0;
            foreach (var row in jagged1)
            {
                foreach (var numz in row)
                {
                    first++;
                }
            }
            var second = 0;
            foreach (var row in jagged2)
            {
                foreach (var numz in row)
                {
                    second++;
                }
            }

            Console.WriteLine($"The total number of cells is: {first + second}");
        }

        private static bool CheckIfMatrix(int[][] jagged1, int[][] jagged2)
        {
            int length = jagged1[0].Length + jagged2[0].Length;

            for (int row = 1; row < jagged1.GetLength(0); row++)
            {
                if (length == jagged1[row].Length + jagged2[row].Length)
                {
                    continue;

                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private static int[][] CreateJagged(int num)
        {
            var jagged = new int[num][];

            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x)).ToArray();

                jagged[row] = new int[input.Length];

                for (int col = 0; col < jagged[row].Length; col++)
                {
                    jagged[row][col] = input[col];
                }
            }
            return jagged;
        }
    }
}