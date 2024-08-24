using AspBlog.Abstractions.Repositories;
using AspBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspBlog.Infrastructure.Repositories
{
    public class PostRepository(BlogDbContex dbContex) : BaseRepository<Post>(dbContex, dbContex.Posts), IPostRepository<Post, PostInfo>
    {
        protected readonly DbSet<PostInfo> _postInfos = dbContex.PostInfos;

        protected IQueryable<PostInfo> GetAllInfosQuery() => _postInfos.AsNoTracking();

        public async Task<IEnumerable<PostInfo>> GetAllInfosAsync() => await GetAllInfosQuery().ToListAsync();

        public async Task<PostInfo?> GetInfoByIdAsync(int id) => await _postInfos.FindAsync(id);
    }
}