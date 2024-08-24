using AspBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspBlog.Infrastructure
{
    public class BlogDbContex : DbContext
    {
        public readonly DbSet<Post> Posts;

        public BlogDbContex(DbContextOptions options) : base(options)
        {
            Posts = Set<Post>();
        }
    }
}