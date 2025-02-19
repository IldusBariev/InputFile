using System.Text.Json.Serialization;

namespace APIshka.Request
{
    public class CreateNewsRequest
    {
        [JsonPropertyName("title")]
        public string Title { get ; set; }

        [JsonPropertyName("description")]
        public string Description { get ; set; }

        [JsonPropertyName("image")]
        public IFormFile Image { get ; set; }
    }
}
