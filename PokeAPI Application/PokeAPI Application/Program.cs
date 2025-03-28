namespace PokeAPI_Application
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    internal class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static List<Pokemon> requestedPokemon = new List<Pokemon>();

        static async Task Main()
        {
            while (true)
            {
                Console.Write("Enter Pokémon name or ID (or 'exit' to quit): ");
                string input = Console.ReadLine().ToLower();

                if (input == "exit") break;

                Pokemon pokemon = await GetPokemonAsync(input);
                if (pokemon != null)
                {
                    requestedPokemon.Add(pokemon);
                    DisplayPokemon(pokemon);
                    Console.WriteLine("\nAll requested Pokémon:");
                    foreach (var p in requestedPokemon)
                    {
                        Console.WriteLine($"- {p.name}");
                    }
                }
            }
        }

        static async Task<Pokemon> GetPokemonAsync(string nameOrId)
        {
            try
            {
                string url = $"https://pokeapi.co/api/v2/pokemon/{nameOrId}";
                string response = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<Pokemon>(response);
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("Error: Pokémon not found or network issue.");
                return null;
            }
            catch (JsonException)
            {
                Console.WriteLine("Error: Invalid data received.");
                return null;
            }
        }

        static void DisplayPokemon(Pokemon pokemon)
        {
            Console.WriteLine($"\nName: {pokemon.name}");
            Console.WriteLine($"Height: {pokemon.height}");
            Console.WriteLine($"Weight: {pokemon.weight}");
            Console.Write("Abilities: ");
            foreach (var ability in pokemon.abilities)
            {
                Console.Write($"{ability.ability.name} ");
            }
            Console.WriteLine();
        }
    }
    }

