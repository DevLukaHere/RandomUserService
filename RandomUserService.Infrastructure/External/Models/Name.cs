using System.Text.Json.Serialization;

namespace RandomUserService.Infrastructure.External.Models
{
    internal class Name
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("first")]
        public string First { get; set; } = string.Empty;

        [JsonPropertyName("last")]
        public string Last { get; set; } = string.Empty;
    }
}
