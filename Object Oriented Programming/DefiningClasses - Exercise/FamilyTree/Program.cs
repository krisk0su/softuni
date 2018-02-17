using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace FamilyTree_
{
    class Program
    {
        static void Main()
        {
            var nameOrDate = Console.ReadLine();


            var person = new Person(nameOrDate);

            var parentList = new List<Parent>();
            var personList = new List<Person>();


            while (true)
            {
                var input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                if (input.Contains("-"))
                {
                    var tokens = input.Split("-", StringSplitOptions.RemoveEmptyEntries);

                    var name = tokens[0].Trim();

                    var parent = new Parent(name);

                    var date = tokens[1].Trim();

                    var child = new Child(date);

                    if (!parentList.Any(x => x.name.Equals(name) || x.date.Equals(name)))
                    {
                        parentList.Add(parent);
                    }

                    parentList.Where(x => x.name.Equals(name) || x.date.Equals(name)).First().children.Add(child);

                }
                else if (!input.Contains("-"))
                {
                    var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    var name = tokens[0] + " " + tokens[1];

                    var date = tokens[2];


                    var per = new Person(name, date);

                    personList.Add(per);
                }


            }

            //ger person full stuff
            foreach (var persons in personList)
            {
                if (persons.name.Equals(person.name))
                {
                    person.date = persons.date;
                }
                else if (persons.date.Equals(person.date))
                {
                    person.name = persons.name;
                }
            }

            var familyTree = new FamilyTree(person);

            foreach (var parent in parentList)
            {
                if (personList.Any(x=> x.name.Equals(parent.name)))
                {
                    parent.date = personList.Where(x => x.name.Equals(parent.name)).First().date;
                }
                else if (personList.Any(x => x.date.Equals(parent.date)))
                {
                    parent.name = personList.Where(x => x.date.Equals(parent.date)).First().name;
                }
            }



            foreach (var kvp in parentList)
            {
                foreach (var child in kvp.children)
                {
                    if (personList.Any(x => x.name.Equals(child.name)))
                    {
                        child.date = personList.Where(x => x.name.Equals(child.name)).First().date;



                    }
                    else if (personList.Any(x => x.date.Equals(child.date)))
                    {
                        child.name = personList.Where(x => x.date.Equals(child.date)).First().name;
                    }
                }
            }

            //get persons parents
            foreach (var parent in parentList)
            {
                foreach (var child in parent.children)
                {
                    if (person.name.Equals(child.name))
                    {
                        familyTree.parents.Add(parent);
                    }
                    
                }
            }

            //get kids
            foreach (var kvp in parentList.Where(x => x.name.Equals(person.name)))
            {
                foreach (var child in kvp.children)
                {
                    familyTree.children.Add(child);
                }
            }

            Console.WriteLine(familyTree.person.name + " " + familyTree.person.date);
            Console.WriteLine("Parents:");
            if (familyTree.parents.Count > 0)
            {
                foreach (var parent in familyTree.parents)
                {
                    Console.WriteLine($"{parent.name} {parent.date}");
                }
            }
            Console.WriteLine("Children:");
            if (familyTree.children.Count > 0)
            {

                foreach (var kid in familyTree.children)
                {
                    Console.WriteLine($"{kid.name} {kid.date}");
                }
            }


        }
    }
}
