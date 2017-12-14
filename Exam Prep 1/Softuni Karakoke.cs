using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_Karaoke
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> participantsNameContainer = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> songListContainer = Console.ReadLine().Split(',').ToList();
            for (int i = 0; i < songListContainer.Count; i++)
            {
                songListContainer[i] = songListContainer[i].Trim();
            }
            var participants = new Dictionary<string, Dictionary<string, string>>();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "dawn")
                {
                    break;
                }


                string[] commands = input.Split(',');
                string name = commands[0];
                string song = commands[1].Trim();
                string award = commands[2];

                if (participantsNameContainer.Contains(name) && songListContainer.Contains(song))
                {
                    if (!participants.ContainsKey(name))
                    {
                        participants.Add(name, new Dictionary<string, string>());
                    }

                    if (!participants[name].ContainsKey(award))
                    {
                        participants[name].Add(award, song);
                    }


                }

            }

            if (participants.Count >= 1)
            {
                foreach (var item in participants.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
                {

                    Console.WriteLine($"{item.Key}: {item.Value.Keys.Count} awards");


                    foreach (var kvp in item.Value.OrderBy(x => x.Key))
                    {
                        Console.WriteLine($"--{kvp.Key.Trim()}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No awards");
            }


        }




    }

}
