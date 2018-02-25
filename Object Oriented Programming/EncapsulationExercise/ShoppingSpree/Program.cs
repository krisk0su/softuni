using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class Program
    {
        static void Main()
        {

            var people = Console.ReadLine().Split(";");
          

            var personList = new List<Person>();

            bool didBreak = false;

            try
            {
                for (int i = 0; i < people.Length; i++)
                {

                    var name = people[i].Split("=", StringSplitOptions.RemoveEmptyEntries)[0].Trim();

                    var money = long.Parse(people[i].Split("=", StringSplitOptions.RemoveEmptyEntries)[1].Trim());



                    
                        var person = new Person(name, money);

                        if (!personList.Any(x => x.Name.Equals(name)))
                        {
                            personList.Add(person);
                        }
                        else
                        {
                            personList.Where(x => x.Name.Equals(name)).First().Money = money;
                        }






                }

                var productList = new List<Product>();
                if (!didBreak)
                {
                    // Bread = 10; Milk = 2;
                    var products = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < products.Length; i++)
                    {
                        var name = products[i].Split("=", StringSplitOptions.RemoveEmptyEntries)[0].Trim();

                        var cost = long.Parse(products[i].Split("=", StringSplitOptions.RemoveEmptyEntries)[1].Trim());

                        var product = new Product(name, cost);




                        if (!productList.Any(x => x.Name.Equals(name)))
                        {
                            productList.Add(product);
                        }
                        else
                        {
                            productList.Where(x => x.Name.Equals(name)).First().Cost = cost;
                        }


                    }


                    while (true)
                    {
                        var input = Console.ReadLine();

                        if (input == "END")
                        {
                            break;
                        }

                        var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                        var name = tokens[0];
                        var product = tokens[1];

                        var personEntity = personList.Where(x => x.Name.Equals(name)).First();
                        var productEntity = productList.Where(x => x.Name.Equals(product)).First();

                        if (personEntity.Money >= productEntity.Cost)
                        {
                            Console.WriteLine($"{name} bought {product}");

                            personEntity.Money -= productEntity.Cost;

                            personEntity.ProductList.Add(productEntity);
                        }
                        else
                        {
                            Console.WriteLine($"{name} can't afford {product}");
                        }
                    }


                    foreach (var person in personList)
                    {
                        if (person.ProductList.Count == 0)
                        {
                            Console.WriteLine($"{person.Name} - Nothing bought");
                        }
                        else
                        {

                            Console.WriteLine($"{person.Name} - {string.Join(", ", person.ProductList)}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }

        }
    }
}
