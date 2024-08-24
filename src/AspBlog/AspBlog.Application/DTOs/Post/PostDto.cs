namespace AspBlog.Application.DTOs.Post
{
    public record PostDto(DateTime CreatedAt, DateTime? ChangedAt, string Title, string Description, string Content) : PostInfoDto(CreatedAt, ChangedAt, Title, Description)
    {
    }
}