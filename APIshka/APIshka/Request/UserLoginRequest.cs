using System.Text.Json.Serialization;

namespace APIshka.Request
{
    public class UserLoginRequest
    {
        [JsonPropertyName("username")]
        public string Username {  get; set; }
        [JsonPropertyName("password")]
        public string Password {  get; set; }
    }
}
