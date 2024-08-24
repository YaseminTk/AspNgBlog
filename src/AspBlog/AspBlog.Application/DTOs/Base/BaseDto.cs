namespace AspBlog.Application.DTOs.Base
{
    public record BaseDto(DateTime CreatedAt, DateTime? ChangedAt)
    {
    }
}