using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] arr2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            var length = Math.Max(arr1.Length, arr2.Length);

            for (int i = 0; i < length; i++)
            {

                if (arr1.Length==arr2.Length)
                {
                    Console.WriteLine($"{arr1[i] + arr2[i]}");
                }
                else if (arr1.Length > arr2.Length)
                {
                    Console.WriteLine(arr1[i]+(arr2[i % arr2.Length]));
                }
                else
                {
                    Console.WriteLine(arr1[i % arr1.Length] + (arr2[i]));
                }
            }

        }
    }