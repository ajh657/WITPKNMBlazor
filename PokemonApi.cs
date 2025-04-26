using Newtonsoft.Json;
using WITPKNMBlazor.Data;

namespace WITPKNMBlazor
{
    public class PokemonApi(HttpClient http, PokemonListCache cache) : IPokemonApi
    {
        public async Task<PokemonData> GetPokemon()
        {
            var id = await cache.GetPokemon();
            var request = await http.GetAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
            var data = JsonConvert.DeserializeObject<PokemonApiData>(await request.Content.ReadAsStringAsync());

            //Data Validation for name and sprites
            if (data?.name == null || data?.sprites?.other?.officialartwork?.front_default == null)
            {
                throw new InvalidDataException();
            }

            return new PokemonData
            {
                Name = data.name,
                ArtworkUrl = data.sprites.other.officialartwork.front_default,
            };
        }
    }
}
