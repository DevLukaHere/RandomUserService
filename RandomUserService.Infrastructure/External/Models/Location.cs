using System.Text.Json.Serialization;

namespace RandomUserService.Infrastructure.External.Models
{
    public class Location
    {
        [JsonPropertyName("street")]
        public Street Street { get; set; } = new Street();

        [JsonPropertyName("city")]
        public string City { get; set; } = "";

        [JsonPropertyName("state")]
        public string State { get; set; } = "";

        [JsonPropertyName("country")]
        public string Country { get; set; } = "";

        [JsonPropertyName("postcode")]
        public object Postcode { get; set; } = null!;

        [JsonPropertyName("coordinates")]
        public Coordinates Coordinates { get; set; } = new Coordinates();

        [JsonPropertyName("timezone")]
        public Timezone Timezone { get; set; } = new Timezone();
    }
}
