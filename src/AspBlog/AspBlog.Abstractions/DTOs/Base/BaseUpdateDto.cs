namespace AspBlog.Abstractions.DTOs.Base
{
    public record BaseUpdateDto(int Id)
    {
        public readonly DateTime ChangedAt = DateTime.Now;
    }
}