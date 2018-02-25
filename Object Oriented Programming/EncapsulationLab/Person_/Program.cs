using System;
using System.Collections.Generic;
using System.Linq;

namespace Person_
{
    class Program
    {
        static void Main()
        {
            var personList = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var firstName = tokens[0];

                var lastName = tokens[1];

                var age = int.Parse(tokens[2]);

                var salary = decimal.Parse(tokens[3]);

                Person person = null;
                try
                {
                    person = new Person(tokens[0],
                       tokens[1],
                        int.Parse(tokens[2]),
                        decimal.Parse(tokens[3]));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                personList.Add(person);
            }

            var bonus = decimal.Parse(Console.ReadLine());

            personList.ForEach(x=> x.IncreaseSalary(bonus));

            personList.ForEach(x=> Console.WriteLine(x.ToString()));
        }
    }
}
