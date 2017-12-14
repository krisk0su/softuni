using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> standings = new Dictionary<string, int>();
            Dictionary<string, int> teamGoal = new Dictionary<string, int>();

            string key = Console.ReadLine();
            string line = Console.ReadLine();
            while (!line.Equals("final"))
            {
                string[] lineArgs = line.Split();
                string firstTeamName = GetTeamName(lineArgs[0], key);
                string secondTeamName = GetTeamName(lineArgs[1], key);


                string[] score = lineArgs[2].Split(':');
                int firstTeamGoals = int.Parse(score[0]);
                int secondTeamGoals = int.Parse(score[1]);

                if (firstTeamGoals > secondTeamGoals)
                {
                    AddScoreTeam(standings, firstTeamName, 3);
                    AddScoreTeam(standings, secondTeamName, 0);

                }
                else if (firstTeamGoals < secondTeamGoals)
                {
                    AddScoreTeam(standings, firstTeamName, 0);
                    AddScoreTeam(standings, secondTeamName, 3);
                }
                else
                {
                    AddScoreTeam(standings, firstTeamName, 1);
                    AddScoreTeam(standings, secondTeamName, 1);
                }
                AddScoreTeam(teamGoal, firstTeamName, firstTeamGoals);
                AddScoreTeam(teamGoal, secondTeamName, secondTeamGoals);
                line = Console.ReadLine();
            }
            Console.WriteLine("League standings:");
            var sorted = standings.OrderByDescending(t => t.Value).ThenBy(t => t.Key);
            int countER = 1;
            foreach (var team in sorted)
            {
                Console.WriteLine("{0}. {1} {2}", countER, team.Key, team.Value);
                countER++;
            }
            Console.WriteLine("Top 3 scored goals:");
            var sortedGoals = teamGoal.OrderByDescending(t => t.Value).ThenBy(t => t.Key).Take(3);
            foreach (var team in sortedGoals)
            {
                Console.WriteLine("- {0} -> {1}", team.Key, team.Value);
                countER++;
            }


        }

        private static void AddScoreTeam(Dictionary<string, int> standings, string firstTeamName, int firstTeamScore)
        {

            if (!standings.ContainsKey(firstTeamName))
            {
                standings.Add(firstTeamName, 0);
            }
            standings[firstTeamName] = standings[firstTeamName] + firstTeamScore;

        }

        private static string GetTeamName(string teamName, string key)
        {
            int firstIndex = teamName.IndexOf(key) + key.Length;
            int secondIndex = teamName.LastIndexOf(key);
            int lenghth = secondIndex - firstIndex;
            string name = teamName.Substring(firstIndex, lenghth);
            return string.Join("", name.ToUpper().Reverse());
        }
    }
}
