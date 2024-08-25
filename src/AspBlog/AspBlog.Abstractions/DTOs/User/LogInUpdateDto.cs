using AspBlog.Abstractions.DTOs.Base;

namespace AspBlog.Abstractions.DTOs.User
{
    public record LogInUpdateDto(
        int Id,
        string UserName,
        string Password
        ) : BaseUpdateDto(Id);
}