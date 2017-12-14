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

            if (myArr.Length==1)
            {
                Console.WriteLine(myArr[0]);
            }
            else if (myArr.Length%2==0)
            {
                int firstNum = myArr[myArr.Length/2-1];
                int secondNum = myArr[myArr.Length / 2 ];
                
                var list = new List<int>();
                list.Add(firstNum);
                list.Add(secondNum);
                Console.WriteLine("{{ {0}, {1} }}", firstNum, secondNum);

            }
            else
            {
                int firstNum = myArr[myArr.Length / 2 - 1];
                int secondNum = myArr[myArr.Length / 2];
                int thirdNum = myArr[myArr.Length / 2 + 1];

                Console.WriteLine("{{ {0}, {1}, {2} }}", firstNum , secondNum , thirdNum);
            }

            
        }

        
    }
}
