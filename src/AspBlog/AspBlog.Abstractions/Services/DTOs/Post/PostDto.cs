namespace AspBlog.Abstractions.Services.DTOs.Post
{
    public record PostDto(int Id, DateTime CreatedAt, DateTime? ChangedAt, string Title, string Description, string Content) : PostInfoDto(Id, CreatedAt, ChangedAt, Title, Description);
}