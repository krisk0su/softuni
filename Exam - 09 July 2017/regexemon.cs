using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace regexemon
{
    class Program
    {
        static void Main(string[] args)
        {
            string didiPattern = @"[^a-zA-Z+\-]+";
            string bojoPattern = @"[a-zA-Z]+\-[a-zA-Z]+";

            Regex didi = new Regex(didiPattern);
            Regex bojo = new Regex(bojoPattern);


            string input = Console.ReadLine();


            StringBuilder sb = new StringBuilder();

            sb.Append(input);

            int counter = 0;

            while (true)
            {
                bool regexFound = true;
                if (counter % 2 == 0)
                {
                    Match regex = didi.Match(sb.ToString());
                    string found = regex.ToString();
                    int length = sb.ToString().IndexOf(regex.ToString()) + found.Length;
                    if (regex.Success)
                    {
                        Console.WriteLine(found);
                        sb.Remove(0, length);
                    }
                    else
                    {
                        regexFound = false;
                        break;
                    }

                }
                else if (counter % 2 != 0)
                {
                    Match regex = bojo.Match(sb.ToString());
                    string found = regex.ToString();
                    int length = sb.ToString().IndexOf(regex.ToString()) + found.Length;
                    if (regex.Success)
                    {
                        Console.WriteLine(found);
                        sb.Remove(0, length);
                    }
                    else
                    {
                        regexFound = false;
                        break;
                    }
                }

                if (!regexFound)
                {
                    break;
                }
                counter++;
            }

        }
    }
}
