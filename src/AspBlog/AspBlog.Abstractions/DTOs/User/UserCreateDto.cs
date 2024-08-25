using AspBlog.Abstractions.DTOs.Base;

namespace AspBlog.Abstractions.DTOs.User
{
    public record UserCreateDto(
        string UserName,
        string FullName,
        string Role,
        string Password
        ) : BaseCreateDto;
}