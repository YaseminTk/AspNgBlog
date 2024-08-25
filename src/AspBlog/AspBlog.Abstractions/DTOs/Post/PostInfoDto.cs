using AspBlog.Abstractions.DTOs.Base;
using AspBlog.Abstractions.DTOs.User;

namespace AspBlog.Abstractions.DTOs.Post
{
    public record PostInfoDto(
        int Id,
        DateTime CreatedAt,
        DateTime? ChangedAt,
        string Title,
        string Description,
        int CreatedById,
        int ChangedById,
        UserDto? CreatedBy,
        UserDto? ChangedBy) 
        : BaseDto(Id, CreatedAt, ChangedAt, CreatedById, ChangedById, CreatedBy, ChangedBy)
    {
    }
}