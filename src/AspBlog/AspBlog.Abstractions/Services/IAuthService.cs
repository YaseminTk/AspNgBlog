using AspBlog.Abstractions.DTOs.User;

namespace AspBlog.Abstractions.Services
{
    public interface IAuthService
    {
        public Task<bool> Verify(LogInDto logIn);
    }
}