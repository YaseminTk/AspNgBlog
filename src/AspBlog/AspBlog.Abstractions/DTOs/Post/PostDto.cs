using AspBlog.Abstractions.DTOs.User;

namespace AspBlog.Abstractions.DTOs.Post
{
    public record PostDto(
        int Id,
        DateTime CreatedAt,
        DateTime? ChangedAt,
        string Title,
        string Description,
        string Content,
        int CreatedById,
        UserDto? CreatedBy,
        string? Author)
        : PostInfoDto(Id, CreatedAt, ChangedAt, Title, Description, CreatedById, CreatedBy, Author);
}