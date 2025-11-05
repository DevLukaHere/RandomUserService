using System.Text.Json.Serialization;

namespace RandomUserService.Infrastructure.External.Models
{
    internal class Login
    {
        [JsonPropertyName("uuid")]
        public string Uuid { get; set; } = string.Empty;

        [JsonPropertyName("username")]
        public string Username { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;

        [JsonPropertyName("salt")]
        public string Salt { get; set; } = string.Empty;

        [JsonPropertyName("md5")]
        public string Md5 { get; set; } = string.Empty;

        [JsonPropertyName("sha1")]
        public string Sha1 { get; set; } = string.Empty;

        [JsonPropertyName("sha256")]
        public string Sha256 { get; set; } = string.Empty;
    }
}
