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

            //Data Validation
            if (data?.name == null
                || data?.sprites?.front_default == null
                || data?.sprites?.other?.officialartwork?.front_default == null
                || data?.cries?.latest == null
                || data?.types == null
                )
            {
                throw new InvalidDataException();
            }

            return new PokemonData
            {
                Name = data.name,
                ArtworkUrl = data.sprites.other.officialartwork.front_default,
                SpriteUrl = data.sprites.front_default,
                TypeUrlList = data.types.Where(x => x.type.url != null).Select(x => x.type.url).ToArray()
            };
        }
    }
}
