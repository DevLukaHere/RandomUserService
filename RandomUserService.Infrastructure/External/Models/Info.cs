using System.Text.Json.Serialization;

namespace RandomUserService.Infrastructure.External.Models
{
    internal class Info
    {
        [JsonPropertyName("seed")]
        public string Seed { get; set; } = string.Empty;

        [JsonPropertyName("results")]
        public int Results { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; } = string.Empty;
    }
}
