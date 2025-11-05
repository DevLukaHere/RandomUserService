using System.Text.Json.Serialization;

namespace RandomUserService.Infrastructure.External.Models
{
    internal class Location
    {
        [JsonPropertyName("street")]
        public Street Street { get; set; } = new();

        [JsonPropertyName("city")]
        public string City { get; set; } = string.Empty;

        [JsonPropertyName("state")]
        public string State { get; set; } = string.Empty;

        [JsonPropertyName("country")]
        public string Country { get; set; } = string.Empty;

        [JsonPropertyName("postcode")]
        public string Postcode { get; set; } = string.Empty;

        [JsonPropertyName("coordinates")]
        public Coordinates Coordinates { get; set; } = new();

        [JsonPropertyName("timezone")]
        public Timezone Timezone { get; set; } = new();
    }
}
