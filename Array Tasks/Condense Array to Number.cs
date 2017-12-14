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

            int[] myArr = Console.ReadLine().Split().Select(int.Parse).ToArray();


            while (myArr.Length!=1)
            {
                int[] condensed = new int[myArr.Length - 1];

                for (int i = 0; i < condensed.Length; i++)
                {
                    condensed[i] = myArr[i] + myArr[i + 1];

                }

                myArr = condensed;
            }

            Console.WriteLine(myArr[0]);
        
            
        }

        
    }
}
