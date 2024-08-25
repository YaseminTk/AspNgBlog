using AspBlog.Abstractions.DTOs.Base;
using System.Text.Json.Serialization;

namespace AspBlog.Abstractions.DTOs.Post
{
    public record PostCreateDto(string Title, string Description, string Content) : BaseCreateDto()
    {
        [JsonIgnore]
        public int CreatedById { get; set; }
    };
}