namespace AspBlog.Abstractions.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        public Task<IEnumerable<TEntity>> GetAllAsync();

        public Task<TEntity?> GetByIdAsync(int id);

        public Task<bool> CreateAsync(TEntity entity);

        public Task<int> CreateAsync(params TEntity[] entities);

        public Task<bool> UpdateAsync(TEntity entity);

        public Task<int> UpdateAsync(params TEntity[] entities);

        public Task<bool> DeleteAsync(TEntity entity);

        public Task<int> DeleteAsync(params TEntity[] entities);
    }
}