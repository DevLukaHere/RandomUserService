using System.Text.Json.Serialization;

namespace RandomUserService.Infrastructure.External.Models
{
    public class Timezone
    {
        [JsonPropertyName("offset")]
        public string Offset { get; set; } = "";

        [JsonPropertyName("description")]
        public string Description { get; set; } = "";
    }
}
