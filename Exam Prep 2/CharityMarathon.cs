sing System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prepExam2
{
    class CharityMarathon
    {
        static void Main(string[] args)
        {
            var marathonDays = decimal.Parse(Console.ReadLine());
            var numOfRunners = decimal.Parse(Console.ReadLine());
            var numberOfLaps = decimal.Parse(Console.ReadLine());
            //how long is the trach
            var trackLenght = decimal.Parse(Console.ReadLine());
            //how many runneers can run at once
            var trackCapacity = decimal.Parse(Console.ReadLine());
            var moneyPerKilometer = decimal.Parse(Console.ReadLine());

            var totalRunners = Math.Min(numOfRunners,trackCapacity * marathonDays);

            var totalMeters = totalRunners * numberOfLaps * trackLenght;
            var totalKilometers = totalMeters / 1000;

            var moneyRaised = totalKilometers * moneyPerKilometer;


            Console.WriteLine($"Money raised: {moneyRaised:F2}");




        }
    }
}