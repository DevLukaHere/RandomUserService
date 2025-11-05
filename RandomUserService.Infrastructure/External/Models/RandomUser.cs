using System.Text.Json.Serialization;

namespace RandomUserService.Infrastructure.External.Models
{
    internal class RandomUser
    {
        [JsonPropertyName("gender")]
        public string Gender { get; set; } = string.Empty;

        [JsonPropertyName("name")] 
        public Name Name { get; set; } = new();

        [JsonPropertyName("location")]
        public Location Location { get; set; } = new();

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("login")]
        public Login Login { get; set; } = new();

        [JsonPropertyName("dob")]
        public Dob Dob { get; set; } = new();

        [JsonPropertyName("registered")]
        public Registered Registered { get; set; } = new();

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonPropertyName("cell")]
        public string Cell { get; set; } = string.Empty;

        [JsonPropertyName("id")]
        public Id Id { get; set; } = new();

        [JsonPropertyName("picture")]
        public Picture Picture { get; set; } = new();

        [JsonPropertyName("nat")]
        public string Nat { get; set; } = string.Empty;
    }
}
