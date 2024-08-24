using AspBlog.Application.DTOs.Base;

namespace AspBlog.Application.DTOs.Post
{
    public record PostUpdateDto(string Title, string Description, string Content) : BaseUpdateDto
    {
    }
}