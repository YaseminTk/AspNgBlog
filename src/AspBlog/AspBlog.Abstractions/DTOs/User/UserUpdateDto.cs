using AspBlog.Abstractions.DTOs.Base;

namespace AspBlog.Abstractions.DTOs.User
{
    public record UserUpdateDto(
        int Id,
        string UserName,
        string FullName,
        string Role,
        string Password
        ) : BaseUpdateDto(Id);
}