using AspBlog.Application.DTOs.Base;

namespace AspBlog.Application.DTOs
{
    public record PostInfoDto(DateTime CreatedAt, DateTime? ChangedAt, string Title, string Description) : BaseDto(CreatedAt, ChangedAt)
    {
    }
}