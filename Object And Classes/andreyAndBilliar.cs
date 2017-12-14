using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace andreyAndBilliard
{
    class Program
    {
        static void Main(string[] args)
        {
            int entitiesNum = int.Parse(Console.ReadLine());
            var listOfproducts = new List<Product>();

            for (int i = 0; i < entitiesNum; i++)
            {
                string[] input = Console.ReadLine().Split('-');

                string entity = input[0];
                double price = double.Parse(input[1]);



                if (!listOfproducts.Any(x => x.Entity.Equals(entity)))
                {
                    var product = new Product();
                    product.Entity = entity;
                    product.Price = price;

                    listOfproducts.Add(product);
                }
                else
                {
                    var index = listOfproducts.FindIndex(x => x.Entity.Equals(entity));
                    listOfproducts[index].Price = price;

                }

            }

            var customers = new List<Customer>();
            while (true)
            {
                string input = Console.ReadLine();

                if (input.Equals("end of clients"))
                {
                    break;
                }

                string[] cmds = input.Split(new char[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = cmds[0];
                string product = cmds[1];
                int quantity = int.Parse(cmds[2]);



                if (listOfproducts.Any(x => x.Entity == product))
                {
                    if (!customers.Any(x => x.Name == name))
                    {
                        var customche = new Customer();
                        if (quantity>0)
                        {
                            customche.Name = name;
                            customche.Orders = new Dictionary<string, int>();
                            customche.Orders.Add(product, quantity);

                            customers.Add(customche);
                        }
                        
                    }
                    else
                    {
                        var index = customers.FindIndex(x => x.Name.Equals(name));
                        if (customers[index].Orders.ContainsKey(product))
                        {
                            customers[index].Orders[product] += quantity;
                        }
                        else
                        {
                            customers[index].Orders.Add(product, quantity);
                        }
                    }
                }

            }
            double totalBill = 0;

            foreach (var customer in customers.OrderBy(x => x.Name))
            {
                Console.WriteLine(customer.Name);

                foreach (var order in customer.Orders)
                {
                    var index = listOfproducts.FindIndex(x => x.Entity.Equals(order.Key));


                    var price = listOfproducts[index].Price;
                    var sum = order.Value * price;
                    Console.WriteLine($"-- {order.Key} - {order.Value}");
                    Console.WriteLine($"Bill: {sum:F2}");

                    totalBill += sum;
                }

            }
            if (totalBill>0)
            {
                Console.WriteLine($"Total bill: {totalBill:F2}");
            }
           




        }
    }


    public class Product
    {
        public string Entity { get; set; }

        public double Price { get; set; }
    }

    public class Customer
    {
        public string Name { get; set; }

        public Dictionary<string, int> Orders { get; set; }
    }
}
