using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using System.Text.RegularExpressions;
namespace Roli___The_Coder
{
    class Program
    {
        static void Main(string[] args)
        {
            var myDict = new Dictionary<int, Dictionary<string, List<string>>>();
            string pattern = @"^[@(\w)\'\-]+";
            Regex regex = new Regex(pattern);

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Time for Code")
                {
                    break;
                }


                string[] tokens = input.Split().ToArray();
                int id = int.Parse(tokens[0]);
                string evenName = tokens[1];
               

               
                
                if (evenName.StartsWith("#"))
                {
                    var listOfParticipants = new List<string>();
                    for (int i = 2; i < tokens.Length; i++)
                    {
                        
                        if (tokens[i].StartsWith("@"))
                        {
                            Match match = regex.Match(tokens[i]);
                            if (match.Success)
                            {
                                listOfParticipants.Add(tokens[i]);
                            }
                            
                        }
                    }
                    var tempDict = new Dictionary<string, List<string>>();
                    tempDict.Add(evenName, listOfParticipants);

                    if (!myDict.ContainsKey(id))
                    {
                        myDict.Add(id, tempDict);
                    }
                    else
                    {
                        if (myDict[id].ContainsKey(evenName))
                        {
                            foreach (var list in myDict[id].Values)
                            {

                                for (int i = 0; i < listOfParticipants.Count; i++)
                                {
                                    if (!list.Contains(listOfParticipants[i]))
                                    {
                                        myDict[id][evenName].Add(listOfParticipants[i]);
                                    }
                                }



                            }
                        }
                    }
                }
                
            }

            var sorted = new Dictionary<string, List<string>>();
            foreach (var dictionary in myDict)
            {

                foreach (var kvp in dictionary.Value)
                {

                    var tempList = new List<string>();
                    foreach (var participants in kvp.Value)
                    {


                        tempList.Add(participants);
                    }
                    sorted.Add(kvp.Key, tempList);
                }

            }

            foreach (var kvp in sorted.OrderByDescending(x => x.Value.Count).ThenBy(x=> x.Key))
            {
                string[] namez = kvp.Key.ToString().Split('#').ToArray();
                string name = namez[1];
                Console.WriteLine($"{name} - {kvp.Value.Count}");
                foreach (var player in kvp.Value.OrderBy(a => a))
                {

                    Console.WriteLine(player);
                }
            }
        }
    }
}
