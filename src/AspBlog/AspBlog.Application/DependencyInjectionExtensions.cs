using AspBlog.Abstractions.Services;
using AspBlog.Application.DTOs.Post;
using AspBlog.Application.DTOs;
using AspBlog.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using AspBlog.Abstractions.Repositories;
using AspBlog.Application.Services;

namespace AspBlog.Application
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddPostService(this IServiceCollection services) => services.AddScoped
            <IPostService<Post, PostInfo, IPostRepository<Post, PostInfo>, PostDto, PostInfoDto, PostCreateDto, PostUpdateDto>, PostService>();
    }
}