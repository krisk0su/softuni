using System;
using System.Collections.Generic;
using System.Runtime.Versioning;

namespace PizzaCalories
{
    class Program
    {
        static void Main()
        {
            try
            {
                var toppingList = new List<Toppings>();

            

                var name = Console.ReadLine().Split(" ")[1];

                var pizza = new Pizza(name);

                Dough dough = null;

                while (true)
                {
                    var input = Console.ReadLine();

                    if (input == "END")
                    {
                        break;
                    }

                    var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    var product = tokens[0];

                    if (product.ToLower() == "dough")
                    {
                        var flourType = tokens[1];

                        var type = tokens[2];

                        var weight = double.Parse(tokens[3]);


                        dough = new Dough(flourType, type, weight);

                        pizza.Dough = dough;
                        
                    }
                    else if (product.ToLower() == "topping")
                    {
                        var type = tokens[1];
                        var weight = double.Parse(tokens[2]);


                        var topping = new Toppings(type, weight);
                        toppingList.Add(topping);

                    }
                }


                pizza.ToppingList = toppingList;

               pizza.CalculateCalories();
                 
              
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
              
            }
            

            

        }
    }
}
