using System.Text.Json.Serialization;

namespace RandomUserService.Infrastructure.External.Models
{
    public class UserResult
    {
        [JsonPropertyName("gender")]
        public string Gender { get; set; } = "";

        [JsonPropertyName("name")]
        public Name Name { get; set; } = new Name();

        [JsonPropertyName("location")]
        public Location Location { get; set; } = new Location();

        [JsonPropertyName("email")]
        public string Email { get; set; } = "";

        [JsonPropertyName("login")]
        public Login Login { get; set; } = new Login();

        [JsonPropertyName("dob")]
        public Dob Dob { get; set; } = new Dob();

        [JsonPropertyName("registered")]
        public Registered Registered { get; set; } = new Registered();

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = "";

        [JsonPropertyName("cell")]
        public string Cell { get; set; } = "";

        [JsonPropertyName("id")]
        public Id Id { get; set; } = new Id();

        [JsonPropertyName("picture")]
        public Picture Picture { get; set; } = new Picture();

        [JsonPropertyName("nat")]
        public string Nat { get; set; } = "";
    }
}
