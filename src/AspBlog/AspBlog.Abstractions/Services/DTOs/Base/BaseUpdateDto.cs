namespace AspBlog.Abstractions.Services.DTOs.Base
{
    public record BaseUpdateDto
    {
        public readonly DateTime ChangedAt = DateTime.Now;
    }
}