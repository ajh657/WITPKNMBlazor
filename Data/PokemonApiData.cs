using Newtonsoft.Json;

namespace WITPKNMBlazor.Data
{
    public class Cries
    {
        public required string latest { get; set; }
    }

    public class OfficialArtwork
    {
        public string? front_default { get; set; }
    }

    public class OtherArtwork
    {
        [JsonProperty("official-artwork")]
        public OfficialArtwork? officialartwork { get; set; }
    }

    public class PokemonApiData
    {
        public Cries? cries { get; set; }
        public string? name { get; set; }
        public Sprites? sprites { get; set; }
        public List<Type>? types { get; set; }
    }

    public class Sprites
    {
        public string? front_default { get; set; }
        public OtherArtwork? other { get; set; }
    }

    public class Type
    {
        public int slot { get; set; }
        public required Typename type { get; set; }
    }

    public class Typename
    {
        public string? name { get; set; }
        public string? url { get; set; }
    }

    public class Version
    {
        public required string name { get; set; }
        public required string url { get; set; }
    }
}
