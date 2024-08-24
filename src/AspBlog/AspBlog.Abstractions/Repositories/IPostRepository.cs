namespace AspBlog.Abstractions.Repositories
{
    public interface IPostRepository<TPost, TPostInfo> : IBaseRepository<TPost> where TPost : TPostInfo
    {
        public Task<IEnumerable<TPostInfo>> GetAllInfosAsync();

        public Task<TPostInfo?> GetInfoByIdAsync(int id);
    }
}