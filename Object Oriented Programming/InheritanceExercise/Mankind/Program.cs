using System;

namespace Mankind
{
    class Program
    {
        static void Main()
        {
            try
            {
                var tokens = Console.ReadLine().Split();
                var student = new Student(tokens[0], tokens[1], tokens[2]);

                var toks = Console.ReadLine().Split();
                var worker = new Worker(toks[0], toks[1], double.Parse(toks[2]), double.Parse(toks[3]));

                Console.WriteLine(student.ToString());
                Console.WriteLine(worker.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
           
        }
    }
}
