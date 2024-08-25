using AspBlog.Abstractions.DTOs.User;

namespace AspBlog.Abstractions.Services
{
    public interface IUserService<TUser> : IBaseService<TUser, UserDto, UserCreateDto, UserUpdateDto>
    {
        public Task<UserDto?> GetByUserNameAsync(string userName);

        public Task<bool> UpdateAsync(RoleUpdateDto dto);
    }
}