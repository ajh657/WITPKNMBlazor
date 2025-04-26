using System.Text.RegularExpressions;
using Newtonsoft.Json;
using WITPKNMBlazor.Data;

namespace WITPKNMBlazor
{
    public class PokemonListCache(HttpClient http)
    {
        private int[] _cache = [];

        public async Task<int> GetPokemon()
        {
            if (_cache.Length == 0)
            {
                _cache = await GetPokemonsFromApi();
            }

            return _cache[new Random().Next(_cache.Length)];
        }

        private async Task<int[]> GetPokemonsFromApi()
        {
            var request = await http.GetAsync($"https://pokeapi.co/api/v2/pokemon?limit=1302");
            var data = JsonConvert.DeserializeObject<PokemonList>(await request.Content.ReadAsStringAsync());

            //Parse pokemon id's from the urls to an int array
            var list = data.results.Select(x => ExtractId(x.url)).Where(x => x != null).Cast<string>();
            return list.Select(int.Parse).ToArray();
        }

        private static string? ExtractId(string url)
        {
            //Regex to capture the id from the url end example: https://pokeapi.co/api/v2/pokemon/38/ would only return 38
            var matches = Regex.Match(url, @"(?<=\/)\d+(?=\/)");

            if (matches.Success)
            {
                return matches.Value;
            }
            else
            {
                return null;
            }
        }
    }
}
