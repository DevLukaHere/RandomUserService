using System.Text.Json.Serialization;

namespace RandomUserService.Infrastructure.External.Models
{
    internal class Coordinates
    {
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; } = string.Empty;

        [JsonPropertyName("longitude")]
        public string Longitude { get; set; } = string.Empty;
    }
}
