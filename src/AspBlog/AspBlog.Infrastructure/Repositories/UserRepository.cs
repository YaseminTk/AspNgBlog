using AspBlog.Abstractions.Repositories;
using AspBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspBlog.Infrastructure.Repositories
{
    public class UserRepository(BlogDbContex dbContex) : BaseRepository<User>(dbContex, dbContex.Users), IUserRepository<User>
    {
        public async Task<User?> GetByUserNameAsync(string userName) => await _dbSet.AsNoTracking()
            .Where(user => user.UserName == userName)
            .FirstOrDefaultAsync();
    }
}