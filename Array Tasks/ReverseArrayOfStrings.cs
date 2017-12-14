using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lastKelements
{
    class Program
    {
        static void Main(string[] args)
        {
             string[] input = Console.ReadLine().Split();

            for (int i = 0; i < input.Length/2; i++)
            {
                string buffer = input[i];
                input[i] = input[input.Length - 1 - i];
                input[input.Length - 1 - i] = buffer;
            }

            Console.WriteLine(string.Join(" ", input));
        }

        //input.reverse() easy way
    }
}