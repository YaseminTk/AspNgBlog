namespace AspBlog.Abstractions.DTOs.User
{
    public record LogInDto(
        string UserName,
        string Password
        );
}