using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesMan
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var engineList = new List<Engine>();

            for (int i = 0; i < n ; i++)
            {
                var tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var model = tokens[0];

                var power = double.Parse(tokens[1]);
                if (tokens.Length==2)
                {
                   var engine = new Engine(model, power);
                    engineList.Add(engine);
                }

                if (tokens.Length==3 && int.TryParse(tokens[2], out int res))
                {
                    var displacement = int.Parse(tokens[2]);
                    var engine = new Engine(model, power, displacement.ToString());
                    engineList.Add(engine);
                }
                else if (tokens.Length==3)
                {
                    var efficiency = tokens[2];
                    var engine = new Engine(model, power, efficiency);
                    engineList.Add(engine);
                }

                if (tokens.Length==4)
                {
                    var displacement = int.Parse(tokens[2]);
                    var efficiency = tokens[3];
                    var engine = new Engine(model, power, displacement.ToString(), efficiency);
                    engineList.Add(engine);

                }
            }

            var num = int.Parse(Console.ReadLine());

            var carList = new List<Car>();

            for (int i = 0; i < num; i++)
            {
                var tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var model = tokens[0];

                var engine = engineList.Where(x => x.model.Equals(tokens[1])).First();

                if (tokens.Length==2)
                {   
                    
                    var car = new Car(model, engine);
                    carList.Add(car);
                }

                if (tokens.Length==3 && double.TryParse(tokens[2], out double res))
                {
                    var car = new Car(model, engine, res.ToString());
                    carList.Add(car);
                }
                else if (tokens.Length==3)
                {
                    var color = tokens[2];

                    var car = new Car(model, engine, color);

                    carList.Add(car);
                }

                if (tokens.Length==4)
                {
                    var power = double.Parse(tokens[2]);
                    var color = tokens[3];

                    var car = new Car(model, engine, power.ToString(), color);

                    carList.Add(car);
                }
            }


            foreach (var car in carList)
            {
                Console.WriteLine($"{car.model}:");
                Console.WriteLine($"  {car.engine.model}:");
                Console.WriteLine($"    Power: {car.engine.power}");
                Console.WriteLine($"    Displacement: {car.engine.dispacement}");
                Console.WriteLine($"    Efficiency: {car.engine.efficiency}");
                Console.WriteLine($"  Weight: {car.weigth}");
                Console.WriteLine($"  Color: {car.color}");
            }
        }

    }
}
