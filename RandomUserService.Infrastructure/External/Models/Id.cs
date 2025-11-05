using System.Text.Json.Serialization;

namespace RandomUserService.Infrastructure.External.Models
{
    internal class Id
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("value")]
        public string Value { get; set; } = string.Empty;
    }
}
