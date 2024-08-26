using AspBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AspBlog.Infrastructure
{
    public class BlogDbContex : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        
        public DbSet<PostInfo> PostInfos { get; set; }

        public DbSet<User> Users { get; set; }

        public BlogDbContex(DbContextOptions options) : base(options)
        {
            Posts = Set<Post>();

            PostInfos = Set<PostInfo>();

            Users = Set<User>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // initial admin account
            PasswordHasher<string> passwordHasher = new();
            string full_name = "Admin";
            string user_name = full_name.ToLower();
            string hashed_password = passwordHasher.HashPassword(user_name, user_name);

            modelBuilder.Entity<User>().HasData(
                new User {
                    Id = -1,
                    FullName = full_name,
                    UserName = user_name,
                    PasswordHash = hashed_password,
                    CreatedAt = DateTime.Now,
                    Role = "admin"}
                );
        }
    }
}