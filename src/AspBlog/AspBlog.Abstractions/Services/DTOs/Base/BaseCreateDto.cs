namespace AspBlog.Abstractions.Services.DTOs.Base
{
    public record BaseCreateDto
    {
        public readonly DateTime CreatedAt = DateTime.Now;
    }
}