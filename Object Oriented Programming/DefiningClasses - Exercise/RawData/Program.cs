using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var cars = new List<Car>();


            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var model = tokens[0];

                var power = int.Parse(tokens[2]);
                var engine = new Engine(power);

                var cargoType = tokens[4];
                var cargo = new Cargo(cargoType);

                var pressure1 = double.Parse(tokens[5]);
                var tire1 = new Tire(pressure1);

                var pressure2 = double.Parse(tokens[7]);
                var tire2 = new Tire(pressure2);

                var pressure3 = double.Parse(tokens[9]);
                var tire3 = new Tire(pressure3);

                var pressure4 = double.Parse(tokens[11]);
                var tire4 = new Tire(pressure3);

                var tireList = new List<Tire>();
                tireList.Add(tire1);
                tireList.Add(tire2);
                tireList.Add(tire3);
                tireList.Add(tire4);

                var car = new Car(model, cargo, engine, tireList);

                cars.Add(car);
            }

            var input = Console.ReadLine();

            if (input== "fragile")
            {
                var res = cars.Where(x => x.cargo.cargo == "fragile" && x.tires.Any(z => z.pressure < 1));

                foreach (var car in res)
                {
                    Console.WriteLine($"{car.model}");
                }
            }
            else if (input == "flamable")
            {
                var res = cars.Where(x => x.cargo.cargo == "flamable" && x.engine.enginePower > 250);

                foreach (var car in res)
                {
                    Console.WriteLine($"{car.model}");
                }
            }
        }
    }
}
