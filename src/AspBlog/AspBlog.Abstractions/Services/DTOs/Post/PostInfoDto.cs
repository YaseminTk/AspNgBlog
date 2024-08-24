using AspBlog.Abstractions.Services.DTOs.Base;

namespace AspBlog.Abstractions.Services.DTOs.Post
{
    public record PostInfoDto(DateTime CreatedAt, DateTime? ChangedAt, string Title, string Description) : BaseDto(CreatedAt, ChangedAt)
    {
    }
}