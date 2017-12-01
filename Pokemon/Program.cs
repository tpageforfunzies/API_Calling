using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Base_Experience { get; set; }
        public int Height { get; set; }
    }

    class Program
    {
        static HttpClient client = new HttpClient();

        static void ShowPokemon(Pokemon pokemon)
        {
            Console.WriteLine("Id: " + pokemon.Id);
            Console.WriteLine("Name: " + pokemon.Name);
            Console.WriteLine("Base Experience: " + pokemon.Base_Experience);
            Console.WriteLine("Height: " + pokemon.Height);
        }

        static async Task<Pokemon> GetPokemonAsync(string path)
        {
            Pokemon pokemon = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                pokemon = await response.Content.ReadAsAsync<Pokemon>();
            }

            return pokemon;


        }

        static void Main(string[] args)
        {
                RunAsync().GetAwaiter().GetResult();            
        }

        static async Task RunAsync()
        {
            Pokemon pokemon = new Pokemon();

            client.BaseAddress = new Uri("http://www.pokeapi.co/api/v2/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("" +
                "application/json"));

            try
            {
                Console.WriteLine("Enter a pokemon's name: ");
                string pokemonName = Console.ReadLine();

                pokemon = await GetPokemonAsync($"pokemon/{pokemonName.ToLower()}");
                ShowPokemon(pokemon);



            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
