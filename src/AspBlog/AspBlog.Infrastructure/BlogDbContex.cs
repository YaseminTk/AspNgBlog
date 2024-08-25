using AspBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspBlog.Infrastructure
{
    public class BlogDbContex : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        
        public DbSet<PostInfo> PostInfos { get; set; }

        public BlogDbContex(DbContextOptions options) : base(options)
        {
            Posts = Set<Post>();

            PostInfos = Set<PostInfo>();
        }
    }
}