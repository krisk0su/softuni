using System;

namespace Animals
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input =="Beast!")
                {
                    break;
                }

                var tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


                try
                {
                    var animal = GetAnimal(input, tokens);
                    Console.WriteLine(animal.ToString().TrimEnd());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
        }

        private static object GetAnimal(string input, string[] tokens)
        {
            string name = tokens[0];

            int age = int.Parse(tokens[1]);

            string gender = tokens[2];

            switch (input.ToLower())
            {
                case "dog":
                    return new Dog(name, age, gender);
                case "cat":
                    return new Cat(name, age, gender);
                case "frog":
                    return new Frog(name, age, gender);
                case "kitten":
                    return new Kitten(name, age);
                case "tomcat":
                    return new Tomcat(name, age);
                default:
                    throw new ArgumentException("Invalid input!");
            }

            
           
        }
    }
}
