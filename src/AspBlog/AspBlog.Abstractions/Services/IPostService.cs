using AspBlog.Abstractions.Repositories;
using AspBlog.Abstractions.Services.DTOs.Post;

namespace AspBlog.Abstractions.Services
{
    public interface IPostService<TPost, TPostInfo> : IBaseService<TPost, IPostRepository<TPost, TPostInfo>, PostDto, PostCreateDto, PostUpdateDto>
        where TPost : TPostInfo
    {
        public Task<IEnumerable<PostInfoDto>> GetAllInfosAsync();

        public Task<PostInfoDto?> GetInfoByIdAsync(int id);
    }
}