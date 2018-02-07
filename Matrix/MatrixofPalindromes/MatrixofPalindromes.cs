using System;
using System.Linq;
using System.Text;
namespace MatrixofPalindromes
{
    class Program
    {
        static void Main()
        {

            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            var matrice = new string[input[0], input[1]];

            for (int row = 0; row < matrice.GetLength(0); row++)
            {
                int counter = row;


                for (int column = 0; column < matrice.GetLength(1); column++)
                {
                    var sb = new StringBuilder();

                    for (int z = 0; z < 4; z++)
                    {


                        if (z % 4 == 1)
                        {
                            sb.Append(alphabet[counter]);
                        }
                        else if (z % 4 == 3)
                        {
                            sb.Append(' ');
                        }
                        else
                        {
                            sb.Append(alphabet[row]);
                        }

                    }
                    matrice[row, column] = sb.ToString();

                    counter++;
                }
            }
            int count = 0;
            foreach (var sstring in matrice)
            {
                Console.Write(sstring);
                count++;
                if (count % matrice.GetLength(1) == 0)
                {
                    Console.WriteLine();

                }

            }

        }
    }
}