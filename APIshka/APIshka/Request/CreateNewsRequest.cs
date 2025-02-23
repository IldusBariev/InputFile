using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace APIshka.Request
{
    public class CreateNewsRequest
    {
        [FromForm]
        [JsonPropertyName("title")]
        public string Title { get ; set; }

        [FromForm]
        [JsonPropertyName("description")]
        public string? Description { get ; set; }

        [FromForm]
        [JsonPropertyName("image")]
        public IFormFile? Image { get ; set; }
    }
}
