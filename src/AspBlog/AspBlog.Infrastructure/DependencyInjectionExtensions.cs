using AspBlog.Abstractions.Repositories;
using AspBlog.Domain.Entities;
using AspBlog.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AspBlog.Infrastructure
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddPostRepository(this IServiceCollection services) 
            => services.AddScoped<IPostRepository<Post, PostInfo>, PostRepository>();

        public static IServiceCollection AddUserRepository(this IServiceCollection services)
            => services.AddScoped<IUserRepository<User>, UserRepository>();

        public static IServiceCollection AddBlogRepositories(this IServiceCollection services) => services
            .AddPostRepository()
            .AddUserRepository();
    }
}