using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
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
                var fuelAmount = double.Parse(tokens[1]);
                var fuelConsuptionPerKm = double.Parse(tokens[2]);

                var car  = new Car(model, fuelAmount, fuelConsuptionPerKm);

                if (!cars.Any(x=> x.model.Equals(car.model)))
                {
                    cars.Add(car);
                }
                
            }


            while (true)
            {
                var input = Console.ReadLine();

                if (input=="End")
                {
                    break;
                }

                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var model = tokens[1];

                var amountOfKm = double.Parse(tokens[2]);

                var index = cars.FindIndex(x => x.model.Equals(model));

                bool canMove = cars[index].Move(amountOfKm);

                if (!canMove)
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }


            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.model} {car.fuelAmount:F2} {car.distanceTravelled}");
            }
        }
    }
}
