using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Array_of_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int[] array = new int[input];

            for (int i = 0; i < input; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            Array.Reverse(array);

            foreach (int num in array)
            {
                Console.WriteLine(num);
            }
        }
    }
}