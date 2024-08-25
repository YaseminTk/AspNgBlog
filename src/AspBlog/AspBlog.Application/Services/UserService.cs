using AspBlog.Abstractions.DTOs.User;
using AspBlog.Abstractions.Repositories;
using AspBlog.Abstractions.Services;
using AspBlog.Domain.Entities;
using AutoMapper;

namespace AspBlog.Application.Services
{
    public class UserService(IUserRepository<User> repository, IMapper mapper)
        : BaseService<User, IUserRepository<User>, UserDto, UserCreateDto, UserUpdateDto>(repository, mapper), IUserService<User>
    {
        public async Task<UserDto?> GetByUserNameAsync(string userName)
        {
            var user = await _repository.GetByUserNameAsync(userName);
            return user is null ? null : _mapper.Map<UserDto>(user);
        }
    }
}