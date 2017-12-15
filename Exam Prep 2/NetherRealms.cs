using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            var demonsList = Console.ReadLine()
                .Split(',')
                .Select(a=> a.Trim())
                .OrderBy(name=> name)
                .ToList();

            string healthPattern = @"[^\d\.\+\-\*\/]";
            string dmgPattern = @"(\+\d+\.\d+)|(\-\d+\.\d+)|(\d+\.\d+)|(\+?\-?\d+)|([\/\*])";


            Regex healthRegex = new Regex(healthPattern);
            Regex dmgRegex = new Regex(dmgPattern);

            foreach (var demon in demonsList)
            {
                MatchCollection healthMatch = healthRegex.Matches(demon);
                int healthSum = 0;
                for (int i = 0; i < healthMatch.Count; i++)
                {
                    char temp = char.Parse(healthMatch[i].ToString());
                    healthSum += Convert.ToInt32(temp);
                }
                MatchCollection dmgMatches = dmgRegex.Matches(demon);

                double dmg = 0;

                string operands = "";
                foreach (var value in dmgMatches)
                {
                    

                    if (value.ToString().Equals("*"))
                    {
                        operands += "*";
                    }
                    else if (value.ToString().Equals("/"))
                    {
                        operands += "/";
                    }
                    else
                    {
                        dmg += double.Parse(value.ToString());
                    }
                    

                }
                foreach (var op in operands)
                {
                    if (op=='*')
                    {
                        dmg *= 2;
                    }
                    else if (op=='/')
                    {
                        dmg /= 2;
                    }
                    
                }

                Console.WriteLine($"{demon} - {healthSum} health, {dmg:F2} damage");
               

            }
        }
    }
}
