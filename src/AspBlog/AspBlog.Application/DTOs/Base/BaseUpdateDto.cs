namespace AspBlog.Application.DTOs.Base
{
    public record BaseUpdateDto
    {
        public readonly DateTime ChangedAt = DateTime.Now;
    }
}