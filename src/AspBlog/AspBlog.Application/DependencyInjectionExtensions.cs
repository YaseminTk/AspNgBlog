using AspBlog.Abstractions.Services;
using AspBlog.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using AspBlog.Application.Services;
using Microsoft.AspNetCore.Identity;

namespace AspBlog.Application
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddPostService(this IServiceCollection services) => services.AddScoped<IPostService<Post>, PostService>();

        public static IServiceCollection AddUserService(this IServiceCollection services) => services.AddScoped<IUserService<User>, UserService>();

        public static IServiceCollection AddAuthService(this IServiceCollection services) => services.AddScoped<IAuthService, AuthService>();

        public static IServiceCollection AddBlogServices(this IServiceCollection services) => services
            .AddPostService()
            .AddUserService()
            .AddAuthService()
            .AddScoped<PasswordHasher<string>>()
            .AddAutoMapper(typeof(MappingProfile));
    }
}