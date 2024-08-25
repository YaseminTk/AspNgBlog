using System.Text.Json.Serialization;

namespace AspBlog.Abstractions.DTOs.Base
{
    public record BaseUpdateDto(int Id)
    {
        public readonly DateTime ChangedAt = DateTime.Now;

        [JsonIgnore]
        public int ChangedById { get; set; }
    }
}