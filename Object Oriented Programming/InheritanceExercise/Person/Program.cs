using System;

namespace Person_
{
    class Program
    {
        static void Main()
        {
            try
            {
                var name = Console.ReadLine();
                var age = int.Parse(Console.ReadLine());

                var child = new Child(name, age);

                Console.WriteLine(child.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
               
            }
          
          
           

        }
    }
}
