using System.Text.Json.Serialization;

namespace RandomUserService.Infrastructure.External.Models
{
    public class RandomUserResponse
    {
        [JsonPropertyName("results")]
        public List<UserResult> Results { get; set; } = new List<UserResult>();

        [JsonPropertyName("info")]
        public Info Info { get; set; } = new Info();
    }
}
