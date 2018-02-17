using System;
using System.Collections.Generic;
using System.Linq;

namespace Rectangle_
{
    class Program
    {
        static void Main()
        {

            var nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var recList = new List<Rectangle>();

            for (int i = 0; i < nums[0]; i++)
            {
                var tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var id = tokens[0];

                var width = double.Parse(tokens[1]);

                var height = double.Parse(tokens[2]);

                var cor1 = double.Parse(tokens[3]);

                var cor2 = double.Parse(tokens[4]);

                var cordinates = new List<double>();
                cordinates.Add(cor1);
                cordinates.Add(cor2);

                var rect = new Rectangle(id, width, height, cordinates);

                recList.Add(rect);
            }

            for (int i = 0; i < nums[1]; i++)
            {
                var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var firstId = names[0];

                var secondId = names[1];

                var index = recList.FindIndex(x => x.id.Equals(firstId));

                var rect2 = recList.Where(x => x.id.Equals(secondId)).First();

               bool res = recList[index].CheckIntersect(rect2);

                Console.WriteLine(res.ToString().ToLower());
            }
        }
    }
}
