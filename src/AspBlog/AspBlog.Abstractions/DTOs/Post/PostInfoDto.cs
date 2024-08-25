using AspBlog.Abstractions.DTOs.Base;

namespace AspBlog.Abstractions.DTOs.Post
{
    public record PostInfoDto(int Id, DateTime CreatedAt, DateTime? ChangedAt, string Title, string Description) : BaseDto(Id, CreatedAt, ChangedAt)
    {
    }
}