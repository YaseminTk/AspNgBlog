using AspBlog.Abstractions.Repositories;
using AspBlog.Domain.Entities;
using AspBlog.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AspBlog.Infrastructure
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddPostRepository(this IServiceCollection services) 
            => services.AddScoped<IPostRepository<Post>, PostRepository>();
    }
}