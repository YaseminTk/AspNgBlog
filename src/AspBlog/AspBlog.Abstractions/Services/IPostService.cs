using AspBlog.Abstractions.DTOs.Post;

namespace AspBlog.Abstractions.Services
{
    public interface IPostService<TPost> : IBaseService<TPost, PostDto, PostCreateDto, PostUpdateDto>
    {
        public Task<IEnumerable<PostInfoDto>> GetAllInfosAsync();

        public Task<PostInfoDto?> GetInfoByIdAsync(int id);
    }
}