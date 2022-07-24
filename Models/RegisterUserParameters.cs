namespace Networking.Models
{
    using Newtonsoft.Json;
    public sealed class RegisterUserParameters
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
