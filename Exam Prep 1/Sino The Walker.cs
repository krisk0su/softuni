using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Numerics;
namespace ExamPrep1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime leaveTime = DateTime.ParseExact(Console.ReadLine().ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);

            int numberOfStepsNeeded = int.Parse(Console.ReadLine());

            int timeNeededForSingleStep = int.Parse(Console.ReadLine());


            BigInteger timeInSeconds = (numberOfStepsNeeded * timeNeededForSingleStep);
           
            double hours = 0;
            double minutes = 0;

            while (timeInSeconds>59)
            {
                if (timeInSeconds/3600>=1)
                {
                    hours = (double)(timeInSeconds / 3600);
                    
                    timeInSeconds = timeInSeconds % 3600;
                    
                }
                if (timeInSeconds/60>=1)
                {
                    minutes = (double)(timeInSeconds / 60);
                    timeInSeconds = timeInSeconds % 60;
                }
            }
            double seconds = (double)timeInSeconds;

            leaveTime = leaveTime.AddSeconds(seconds);
            leaveTime = leaveTime.AddMinutes(minutes);
            leaveTime = leaveTime.AddHours(hours);
            
            Console.WriteLine($"Time Arrival: {leaveTime.Hour:D2}:{leaveTime.Minute:D2}:{leaveTime.Second:D2}");

        }
    }
}
