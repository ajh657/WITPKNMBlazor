namespace WITPKNMBlazor.Data
{
    public record PokemonData
    {
        public required string Name;
        public required string[] TypeUrlList;
        public required string ArtworkUrl;
        public required string SpriteUrl;
    }
}
