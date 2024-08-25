using AspBlog.Abstractions.DTOs.Base;

namespace AspBlog.Abstractions.DTOs.User
{
    public record RoleUpdateDto(int Id, string Role) : BaseUpdateDto(Id);
}