namespace AspBlog.Abstractions.Services.DTOs.Base
{
    public record BaseDto(int Id, DateTime CreatedAt, DateTime? ChangedAt);
}