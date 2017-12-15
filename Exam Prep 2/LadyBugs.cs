using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ladyBugs = new int[int.Parse(Console.ReadLine())];

            List<int> ladyBugsIndexes = Console.ReadLine().Split().Select(int.Parse).ToList();

            foreach (var index in ladyBugsIndexes)
            {
                if (index < 0 || index > ladyBugs.Length - 1)
                {
                    continue;
                }
                else
                {
                    ladyBugs[index] = 1;
                }
            }
            int counter = 1;
            while (true & counter <= 100)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] tokens = input.Split().ToArray();

                if (tokens[1].Equals("right"))
                {

                    ladyBugs = LadyBugMovesRight(tokens, ladyBugs);




                }
                else if (tokens[1].Equals("left"))
                {

                    ladyBugs = LadyBugsMovesLeft(tokens, ladyBugs);


                }

                counter++;
            }

            Console.WriteLine(string.Join(" ", ladyBugs));
        }

        public static int[] LadyBugsMovesLeft(string[] tokens, int[] ladyBugs)
        {
            int startIndex = int.Parse(tokens[0]);
            long flyLength = int.Parse(tokens[2]);

            //check if the  the index is outside of the boundaries of the array
            if (startIndex < 0 || startIndex > ladyBugs.Length - 1)
            {
                return ladyBugs;
            }
            //here we check if the ladybugs[starIndex] == 0;
            if (ladyBugs[startIndex] == 0)
            {
                return ladyBugs;
            }
            if (flyLength == 0)
            {
                return ladyBugs;
            }
            //we get this value to 0 because it means the ladybug started flying
            ladyBugs[startIndex] = 0;

            if (flyLength > 0)
            {
                if (startIndex - flyLength >= 0)
                {
                    for (long i = startIndex - flyLength; i >= 0; i-=flyLength)
                    {
                        if (ladyBugs[i] == 0)
                        {
                            ladyBugs[i] = 1;
                            break;
                        }
                    }
                }
            }
            else if (flyLength < 0)
            {
                if (startIndex - flyLength <= ladyBugs.Length - 1)
                {
                    for (long i = startIndex - flyLength; i <= ladyBugs.Length - 1; i+=flyLength)
                    {
                        if (ladyBugs[i] == 0)
                        {
                            ladyBugs[i] = 1;
                            break;
                        }
                    }
                }
            }




            return ladyBugs;
        }

        public static int[] LadyBugMovesRight(string[] tokens, int[] ladyBugs)
        {
            int startIndex = int.Parse(tokens[0]);
            long flyLength = int.Parse(tokens[2]);

            //check if the  the index is outside of the boundaries of the array
            if (startIndex < 0 || startIndex > ladyBugs.Length - 1)
            {
                return ladyBugs;
            }
            //here we check if the ladybugs[starIndex] == 0;
            if (ladyBugs[startIndex] == 0)
            {
                return ladyBugs;
            }
            if (flyLength == 0)
            {
                return ladyBugs;
            }
            //we get this value to 0 because it means the ladybug started flying
            ladyBugs[startIndex] = 0;

            if (flyLength > 0)
            {
                if (startIndex + flyLength <= ladyBugs.Length - 1)
                {
                    for (long i = startIndex + flyLength; i <= ladyBugs.Length - 1; i+=flyLength)
                    {
                        if (ladyBugs[i] == 0)
                        {
                            ladyBugs[i] = 1;
                            break;
                        }
                    }
                }
            }
            else if (flyLength < 0)
            {
                if (startIndex + flyLength >= 0)
                {
                    for (long i = startIndex + flyLength; i >= 0; i-=flyLength)
                    {
                        if (ladyBugs[i] == 0)
                        {
                            ladyBugs[i] = 1;
                            break;
                        }
                    }
                }
            }


            return ladyBugs;
        }
    }
}
