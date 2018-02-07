using System;
using System.Linq;

namespace diagonalDiff
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());

            var matrice = new int[num, num];

            int sum1 = 0;
            int sum2 = 0;

            for (int row = 0; row < matrice.GetLength(0); row++)
            {
                var tempArr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();


                for (int col = 0; col < matrice.GetLength(1); col++)
                {
                    matrice[row, col] = tempArr[col];

                }
            }

            for (int row = 0; row < matrice.GetLength(0); row++)
            {
                sum1 += matrice[row, row];
                sum2 += matrice[row, matrice.GetLength(1) - 1 - row];
            }

            Console.WriteLine(Math.Abs(sum1 - sum2));
        }
    }
}