using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Population_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('|').ToArray();

            var countryPop = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                if (input[0].Equals("report"))
                {
                    break;
                }

                string country = input[1];

                string town = input[0];

                long population = long.Parse(input[2]);

                if (!countryPop.ContainsKey(country))
                {
                    countryPop.Add(country, new Dictionary<string, long>());
                }
                if (!countryPop[country].ContainsKey(town))
                {
                    countryPop[country].Add(town, population);
                }
                else
                {
                    countryPop[country][town] += population;
                }

                input = Console.ReadLine().Split('|').ToArray();
            }




            foreach (var kvp in countryPop.OrderByDescending(kvp=> kvp.Value.Values.Sum()))
            {
                string country = kvp.Key;
                var totalPopulation = kvp.Value.Values.Sum();
                
                Console.WriteLine($"{country} (total population: {totalPopulation})");

                foreach (var town in kvp.Value.OrderByDescending(x=> x.Value))
                {
                    Console.WriteLine($"=>{town.Key}: {town.Value}");
                }

            }


        }
    }
}