using System;

namespace Class_Box
{
    class Program
    {
        static void Main()
        {
            var length = double.Parse(Console.ReadLine());

            var width = double.Parse(Console.ReadLine());

            var heigth = double.Parse(Console.ReadLine());

            Box box = null;


            bool created = false;
            try
            {
                box = new Box(length, width , heigth);
                created = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }

            if (created)
            {
                box.SurfaceArea();
                box.LaternalSurface();
                box.Volume();
            }

        }
    }
}
