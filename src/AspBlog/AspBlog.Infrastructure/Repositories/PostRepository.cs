using AspBlog.Abstractions.Repositories;
using AspBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspBlog.Infrastructure.Repositories
{
    public class PostRepository(DbContext dbContex, DbSet<Post> dbSet) : BaseRepository<Post>(dbContex, dbSet), IPostRepository<Post>
    {
    }
}