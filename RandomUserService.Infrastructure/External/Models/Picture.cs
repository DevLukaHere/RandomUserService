using System.Text.Json.Serialization;

namespace RandomUserService.Infrastructure.External.Models
{
    internal class Picture
    {
        [JsonPropertyName("large")]
        public string Large { get; set; } = string.Empty;

        [JsonPropertyName("medium")]
        public string Medium { get; set; } = string.Empty;

        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; } = string.Empty;
    }
}
