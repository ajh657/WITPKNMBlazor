namespace WITPKNMBlazor.Data
{
    public class Result
    {
        public required string name { get; set; }
        public required string url { get; set; }
    }

    public class PokemonList
    {
        public required List<Result> results { get; set; }
    }

}
