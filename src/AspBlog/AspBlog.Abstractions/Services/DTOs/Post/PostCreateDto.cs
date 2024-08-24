using AspBlog.Abstractions.Services.DTOs.Base;

namespace AspBlog.Abstractions.Services.DTOs.Post
{
    public record PostCreateDto(string Title, string Description, string Content) : BaseCreateDto;
}