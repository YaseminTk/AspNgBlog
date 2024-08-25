using AspBlog.Abstractions.Services;
using AspBlog.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using AspBlog.Application.Services;

namespace AspBlog.Application
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddPostService(this IServiceCollection services) => services.AddScoped<IPostService<Post>, PostService>();
    }
}