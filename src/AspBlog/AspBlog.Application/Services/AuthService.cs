using AspBlog.Abstractions.DTOs.User;
using AspBlog.Abstractions.Repositories;
using AspBlog.Abstractions.Services;
using AspBlog.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AspBlog.Application.Services
{
    public class AuthService(IUserRepository<User> repository, PasswordHasher<string> hasher, IMapper mapper) : IAuthService
    {
        public async Task<bool> Verify(LogInDto logIn)
        {
            var user = await repository.GetByUserNameAsync(logIn.UserName);

            if(user is null)
                return false;

            var res = hasher.VerifyHashedPassword(
                user: logIn.UserName,
                hashedPassword: user.PasswordHash,
                providedPassword: logIn.Password);

            switch (res)
            {
                case PasswordVerificationResult.Success:
                    return true;
                case PasswordVerificationResult.SuccessRehashNeeded:

                    // update password hash
                    var loginUpdate = mapper.Map<LogInUpdateDto>(logIn);
                    user = mapper.Map(loginUpdate, user);
                    await repository.UpdateAsync(user);

                    return true;
                default:
                    return false;
            }
        }
    }
}