using System.Text.Json.Serialization;

namespace RandomUserService.Infrastructure.External.Models
{
    public class Dob
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }
    }
}
