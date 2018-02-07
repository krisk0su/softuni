using System;
using System.Linq;
using System.Collections.Generic;

namespace _2x2SquaresinMatrix
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var matrice = new char[input[0], input[1]];


            for (int rows = 0; rows < matrice.GetLongLength(0); rows++)
            {
                var arr = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => char.Parse(x))
                    .ToArray();



                for (int col = 0; col < matrice.GetLongLength(1); col++)
                {

                    matrice[rows, col] = arr[col];


                }
            }

            int counter = 0;

            for (int row = 0; row < matrice.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrice.GetLength(1) - 1; col++)
                {
                    if (matrice[row, col].Equals(matrice[row, col + 1])
                        && matrice[row, col].Equals(matrice[row + 1, col])
                        && matrice[row, col].Equals(matrice[row + 1, col + 1]))
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}