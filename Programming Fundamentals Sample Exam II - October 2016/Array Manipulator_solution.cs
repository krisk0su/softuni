using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var myArr = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();

            while (true)
            {
                var input = Console.ReadLine();

                if (input=="end")
                {
                    break;
                }
                var commands = input.Split();
                if (commands[0]=="exchange")
                {
                    ExchangeMethod(commands, myArr);
                }
                else if (commands[0]=="min" || commands[0] == "max")
                {
                    var arr = MinMaxMethod(commands, myArr);
                    if (arr.Count==0) Console.WriteLine("No matches");
                    else
                    {
                        if (commands[0]=="max") Console.WriteLine(myArr.LastIndexOf(arr.Max()));
                        else if (commands[0]=="min") Console.WriteLine(myArr.LastIndexOf(arr.Min()));
                    }
                }
                else if (commands[0] == "first" || commands[0] == "last")
                {
                    if (int.Parse(commands[1])>myArr.Count) Console.WriteLine("Invalid count");
                    else
                    {
                        var arr= FirstLastMethod(commands, myArr);
                        if (arr.Count==0) Console.WriteLine("[]");
                        else
                        {
                            int count = int.Parse(commands[1]);
                            if (commands[0]=="first") Console.WriteLine($"[{string.Join(", ", arr.Take(count))}]");
                            else Console.WriteLine($"[{string.Join(", ", arr.Skip(arr.Count - count).Take(count))}]");
                        }
                    }
                }
            }
            Console.WriteLine($"[{string.Join(", ", myArr)}]");
        }
        private static List<int> FirstLastMethod(string[] commands, List<int> myArr)
        {
            if (commands[2]=="even") return myArr.FindAll(x => x % 2 == 0).ToList();
            return myArr.FindAll(x => x % 2 != 0).ToList();
        }
        private static List<int> MinMaxMethod(string[] commands, List<int> myArr)
        {
            if (commands[1] == "even")return myArr.FindAll(x => x % 2 == 0).ToList();
            return myArr.FindAll(x => x % 2 != 0).ToList();
        }
        private static void ExchangeMethod(string[] commands, List<int> myArr)
        {
            int index = int.Parse(commands[1]);

            if (index<0 || index > myArr.Count-1)
            {
                Console.WriteLine("Invalid index");
            }
            else
            {
                List<int> buffer = new List<int>();
                buffer.AddRange(myArr.Skip(index+1).Take(myArr.Count - index + 1));
                buffer.AddRange(myArr.Take(index + 1));
                myArr.Clear();
                myArr.AddRange(buffer);
            }
        }
    }
}
