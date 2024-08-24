using AspBlog.Abstractions.Repositories;

namespace AspBlog.Abstractions.Services
{
    public interface IPostService<TPost, TPostInfo, TPostRepository, TPostDto, TPostInfoDto, TPostCreateDto, TPostUpdateDto>
        : IBaseService<TPost, TPostRepository, TPostDto, TPostCreateDto, TPostUpdateDto>
        where TPost : TPostInfo
        where TPostRepository : IPostRepository<TPost, TPostInfo>
    {
        public Task<IEnumerable<TPostInfoDto>> GetAllInfosAsync();

        public Task<TPostInfoDto?> GetInfoByIdAsync(int id);
    }
}