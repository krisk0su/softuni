using System;
using System.Collections.Generic;
using System.Linq;

namespace Google
{
    class Program
    {
        static void Main()
        {
            var people = new List<Person>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input=="End")
                {
                    break;
                }

                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var personName = tokens[0];


                if (!people.Any(x=> x.name.Equals(personName)))
                {
                    var person = new Person(personName);
                    people.Add(person);


                   
                }

                if (tokens[1]=="company")
                {
                    var companyName = tokens[2];
                    var department = tokens[3];
                    var salary = double.Parse(tokens[4]);

                    
                    var company = new Company(companyName, department, salary);
                    people.Where(x => x.name == personName).First().company = company;
                }
                else if (tokens[1]=="car")
                {
                    var name = tokens[2];

                    var speed = double.Parse(tokens[3]);

                    var car = new Car(name, speed);
                    people.Where(x => x.name == personName).First().car = car;

                }
                else if (tokens[1] == "pokemon")
                {
                    var name = tokens[2];

                    var type = tokens[3];

                    var pokemon = new Pokemon(name, type);

                    people.Where(x => x.name == personName).First().pokemons.Add(pokemon);
                }
                else if (tokens[1]=="children")
                {
                    var name = tokens[2];

                    var date = tokens[3];

                    var child = new Child(name, date);

                    people.Where(x => x.name == personName).First().children.Add(child);
                }
                else if (tokens[1] == "parents")
                {
                    var name = tokens[2];

                    var date = tokens[3];

                    var parent = new Parent(name, date);

                    people.Where(x => x.name == personName).First().parents.Add(parent);
                }
            }

            var nameLine = Console.ReadLine();

            var personFirst = people.Where(x => x.name.Equals(nameLine)).First();

            Console.WriteLine(personFirst.name);
            Console.WriteLine("Company:");
            var companyPrint = personFirst.company.ToString();
            if (companyPrint!="")
            {
                Console.WriteLine(companyPrint);
            }
            Console.WriteLine("Car:");
            var carPrint = personFirst.car.ToString();
            if (carPrint!="")
            {
                Console.WriteLine(carPrint);
            }
            Console.WriteLine("Pokemon:");
            personFirst.PokeString();
            Console.WriteLine("Parents:");
            personFirst.ParentString();
            Console.WriteLine("Children:");
            personFirst.ChildString();

        }
    }
}
