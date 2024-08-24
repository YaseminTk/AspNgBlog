namespace AspBlog.Application.DTOs.Base
{
    public record BaseCreateDto
    {
        public readonly DateTime CreatedAt = DateTime.Now;
    }
}