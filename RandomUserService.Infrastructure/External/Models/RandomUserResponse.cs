using System.Text.Json.Serialization;

namespace RandomUserService.Infrastructure.External.Models
{
    internal class RandomUserResponse
    {
        [JsonPropertyName("results")]
        public List<RandomUser> Results { get; set; } = [];

        [JsonPropertyName("info")]
        public Info Info { get; set; } = new();
    }
}
