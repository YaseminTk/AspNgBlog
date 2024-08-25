namespace AspBlog.Abstractions.DTOs.Base
{
    public record BaseDto(int Id, DateTime CreatedAt, DateTime? ChangedAt);
}