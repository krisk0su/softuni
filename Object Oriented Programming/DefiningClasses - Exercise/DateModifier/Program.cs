using System;

namespace Date_Modifier
{
    class Program
    {
        static void Main()
        {
            var first = Console.ReadLine();

            var second = Console.ReadLine();

            var date = new DateModifier();

            date.Calculate(first, second);
        }
    }
}
