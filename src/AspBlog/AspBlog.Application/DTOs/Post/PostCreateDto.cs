using AspBlog.Application.DTOs.Base;

namespace AspBlog.Application.DTOs.Post
{
    public record PostCreateDto(string Title, string Description, string Content) : BaseCreateDto
    {
    }
}