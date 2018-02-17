using System;
using System.Collections.Generic;
using System.Linq;


namespace DefineAClassPerson
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());

            var list = new List<Person>();

            for (int i = 0; i < num; i++)
            {
                var person = new Person();

                var input = Console.ReadLine().Split();

                person.Name = input[0];

                person.Age = int.Parse(input[1]);

                list.Add(person);

            }


            var res = list.Where(x => x.Age > 30).OrderBy(x => x.Name);

            if (res.Count()> 0)
            {
                foreach (var p in res)
                {
                    Console.WriteLine($"{p.Name} - {p.Age}");
                }
            }

        }
    }
    
}
