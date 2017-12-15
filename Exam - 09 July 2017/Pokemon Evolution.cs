using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Evolution
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, List<Pokemons>>();
            var pokeList = new List<Pokemons>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "wubbalubbadubdub")
                {
                    break;
                }

                if (dict.ContainsKey(input))
                {
                    foreach (var item in dict)
                    {
                        if (item.Key==input)
                        {
                            Console.WriteLine($"# {item.Key}");
                            foreach (var pokemon in dict[input])
                            {

                                
                                Console.WriteLine($"{pokemon.PokemonEvoType} <-> {pokemon.PokemonIndex}");
                            }
                        }
                    }
                   
                }
                
                if(input.Split('-').ToArray().Count()>1)
                {
                    string[] tokens = input.Split(new char[] { '-', '>' },
                    StringSplitOptions.RemoveEmptyEntries).ToArray();

                    string pokemonName = tokens[0].Trim();
                    string pokemonEvo = tokens[1].Trim();
                    int pokemonIndex = int.Parse(tokens[2]);

                    var pokeMon = new Pokemons();
                    pokeMon.PokemonEvoType = pokemonEvo;
                    pokeMon.PokemonIndex = pokemonIndex;
                    
                    if (!dict.ContainsKey(pokemonName))
                    {
                        dict.Add(pokemonName, new List<Pokemons>());
                    }
                    
                        dict[pokemonName].Add(pokeMon);
                   
                }

                

            }
            foreach (var kvp in dict)
            {
                Console.WriteLine($"# { kvp.Key}");

                foreach (var item in kvp.Value.OrderByDescending(x=> x.PokemonIndex))
                {
                    Console.WriteLine($"{item.PokemonEvoType} <-> {item.PokemonIndex}");
                }
            }

           
            
        }
        public class Pokemons
        {
            public string PokemonEvoType { get; set; }

            public int PokemonIndex { get; set; }
        }

    }
}
