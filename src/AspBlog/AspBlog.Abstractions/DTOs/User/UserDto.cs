using AspBlog.Abstractions.DTOs.Base;

namespace AspBlog.Abstractions.DTOs.User
{
    public record UserDto(
        int Id,
        string UserName,
        string FullName,
        string Role,
        DateTime CreatedAt,
        DateTime? ChangedAt,
        int ChangedById,
        UserDto? ChangedBy)
        : BaseDto(Id, CreatedAt, ChangedAt);
}