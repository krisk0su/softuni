using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrepJuly
{
    class Program
    {
        static void Main(string[] args)
        {
            var myList = Console.ReadLine().Split().Select(int.Parse).ToList();

            int valueKeeper = 0;
            while (myList.Count>0)
            {
                int index = int.Parse(Console.ReadLine());
                int value = 0;
                if (index<0)
                {
                    //here we get the value of the index that we want to remove
                    value = myList[0];
                    myList[0] = myList[myList.Count - 1];
                    valueKeeper += value;
                }
                else if (index>myList.Count-1)
                {
                    //here we get the value of the index that we want to remove
                    value = myList[myList.Count - 1];
                    myList[myList.Count - 1] = myList[0];
                    valueKeeper += value;
                }
                else
                {
                    //here we get the value of the index that we want to remove
                    value = myList.ElementAt(index);
                    myList.RemoveAt(index);
                    valueKeeper += value;
                }

                for (int i = 0; i < myList.Count; i++)
                {
                    if (myList[i]<=value)
                    {
                        myList[i] += value;
                    }
                    else if (myList[i]>value)
                    {
                        myList[i] -= value;
                    }
                }
               
            }


            Console.WriteLine(valueKeeper);
        }
    }
}
