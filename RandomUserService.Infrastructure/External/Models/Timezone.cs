using System.Text.Json.Serialization;

namespace RandomUserService.Infrastructure.External.Models
{
    internal class Timezone
    {
        [JsonPropertyName("offset")]
        public string Offset { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
    }
}
