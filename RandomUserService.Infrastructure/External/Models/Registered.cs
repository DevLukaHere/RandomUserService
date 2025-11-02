using System.Text.Json.Serialization;

namespace RandomUserService.Infrastructure.External.Models
{
    public class Registered
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }
    }
}
