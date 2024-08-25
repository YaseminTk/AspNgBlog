using AspBlog.Abstractions.DTOs.Base;

namespace AspBlog.Abstractions.DTOs.Post
{
    public record PostCreateDto(string Title, string Description, string Content) : BaseCreateDto;
}