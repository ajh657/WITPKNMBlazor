using WITPKNMBlazor.Data;

namespace WITPKNMBlazor
{
    public interface IPokemonApi
    {
        Task<PokemonData> GetPokemon(int number);
    }
}