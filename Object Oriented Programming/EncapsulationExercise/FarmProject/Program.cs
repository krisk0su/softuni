using System;

namespace FarmProject
{
    class Program
    {
        static void Main()
        {
            

            var name = Console.ReadLine();

            var age = int.Parse(Console.ReadLine());

            

          

            try
            {
               var  chiken = new Chiken(name, age);
               chiken.ProductPerDay();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }

            
        }
    }
}
