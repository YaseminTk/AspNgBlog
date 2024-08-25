using AspBlog.Abstractions.Services.DTOs.Base;

namespace AspBlog.Abstractions.Services.DTOs.Post
{
    public record PostUpdateDto(int Id, string Title, string Description, string Content) : BaseUpdateDto(Id)
    {
    }
}