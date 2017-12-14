using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var driverList = Console.ReadLine().Split().ToList();

            var zones = Console.ReadLine().Split().Select(double.Parse).ToList();

            var checkPointIndexes = Console.ReadLine().Split().Select(int.Parse).ToList();

            var driversAndFuel = new Dictionary<string, double>();

            foreach (var driver in driverList)
            {
                int fuel = Convert.ToInt32(driver[0]);

                if (!driversAndFuel.ContainsKey(driver))
                {
                    driversAndFuel.Add(driver, fuel);
                }
                else
                {
                    string temptDriver = driver;
                    temptDriver = driver + " ";
                    driversAndFuel.Add(temptDriver, fuel);
                }


            }

            var keys = new List<string>(driversAndFuel.Keys);


            foreach (var driverKey in keys)
            {
                int index = 0;
                for (int z = 0; z < zones.Count; z++)
                {

                    if (checkPointIndexes.Contains(z))
                    {
                        driversAndFuel[driverKey] = driversAndFuel[driverKey] + zones[z];
                    }
                    else
                    {
                        driversAndFuel[driverKey] = driversAndFuel[driverKey] - zones[z];
                    }
                    if (driversAndFuel[driverKey] <= 0)
                    {
                        index = z;
                        break;
                    }
                }

                if (driversAndFuel[driverKey] > 0)
                {
                    Console.WriteLine($"{driverKey.Trim()} - fuel left {driversAndFuel[driverKey]:F2}");
                }
                else
                {
                    Console.WriteLine($"{driverKey.Trim()} - reached {index}");
                }

            }



        }
    }
}
