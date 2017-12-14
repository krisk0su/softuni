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
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            var myArr = new int[n];

            myArr[0] = 1;

            for (int i = 0; i < n-1; i++)
            {
                int sum = 0;

                for (int j = 0; j <k ; j++)
                {
                    if (j<=i)
                    {
                        sum += myArr[i - j];
                    }
                    
                }
                myArr[i+1] = sum;
            }

            Console.WriteLine(string.Join(" ", myArr));
        }
    }
}
