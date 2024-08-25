using AspBlog.Abstractions.DTOs.Base;

namespace AspBlog.Abstractions.DTOs.Post
{
    public record PostUpdateDto(int Id, string Title, string Description, string Content) : BaseUpdateDto(Id)
    {
    }
}