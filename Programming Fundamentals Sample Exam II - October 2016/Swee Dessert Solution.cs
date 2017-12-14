sing System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dessert
{
    class Program
    {
        static void Main(string[] args)
        {   
            decimal cash = decimal.Parse(Console.ReadLine());
            int guest = int.Parse(Console.ReadLine());
            double bananasPrice = double.Parse(Console.ReadLine());
            double eggsPrice = double.Parse(Console.ReadLine());
            double berriePrice = double.Parse(Console.ReadLine());

            if (guest==0)
            {
                guest = 1;
            }
                int portions = guest / 6;
                int portLeft = guest % 6;

                if (portions == 0)
                {
                    portions = 1;
                }
                else if (portLeft != 0 && portLeft < 6)
                {
                    portions += 1;
                }


                double setPortions = (bananasPrice * 2) + (eggsPrice * 4) + (berriePrice * 0.2);
                double cost = (setPortions * portions);
                decimal totalCost = System.Convert.ToDecimal(cost);

                if (cash >= totalCost)
                {
                    Console.WriteLine("Ivancho has enough money - it would cost {0:F2}lv.", totalCost);
                }
                else
                {
                    Console.WriteLine("Ivancho will have to withdraw money - he will need {0:F2}lv more.", Math.Abs(cash - totalCost));
                }
            
            
           
           

           
        
            
        }
    }
}