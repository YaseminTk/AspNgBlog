using AspBlog.Abstractions.Services.DTOs.Base;

namespace AspBlog.Abstractions.Services.DTOs.Post
{
    public record PostInfoDto(int Id, DateTime CreatedAt, DateTime? ChangedAt, string Title, string Description) : BaseDto(Id, CreatedAt, ChangedAt)
    {
    }
}