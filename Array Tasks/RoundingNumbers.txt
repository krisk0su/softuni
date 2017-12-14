using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rounding_Numbers_Away_from_Zero
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            decimal[] array = input.Split().Select(decimal.Parse).ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                decimal effect = array[i] * 100;

                if (effect % 100 == 50 && effect > 0)
                {

                    Console.WriteLine($"{array[i]} => {Math.Ceiling(array[i])}");
                }
                else if (effect < 0)
                {
                    Console.WriteLine($"{array[i]} => {Math.Round(array[i], 0, MidpointRounding.AwayFromZero)}");
                }
                else
                {
                    Console.WriteLine($"{array[i]} => {Math.Round(array[i])}");
                }



            }
            //Console.WriteLine(Math.Round(-2.5, 0, MidpointRounding.AwayFromZero));


        }
    }
}
