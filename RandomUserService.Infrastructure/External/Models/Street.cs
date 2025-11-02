using System.Text.Json.Serialization;

namespace RandomUserService.Infrastructure.External.Models
{
    public class Street
    {
        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";
    }
}
