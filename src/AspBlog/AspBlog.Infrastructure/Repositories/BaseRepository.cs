using AspBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspBlog.Infrastructure.Repositories
{
    public class BaseRepository<TEntity>(DbContext dbContex, DbSet<TEntity> dbSet) where TEntity : BaseEntity
    {
        protected readonly DbContext _dbContex = dbContex;

        protected readonly DbSet<TEntity> _dbSet = dbSet;

        protected IQueryable<TEntity> GetAllQuery() => _dbSet.AsNoTracking();

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await GetAllQuery().ToListAsync();

        public async Task<TEntity?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task<bool> CreateAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            return await _dbContex.SaveChangesAsync() > 0;
        }

        public async Task<int> CreateAsync(params TEntity[] entities)
        {
            foreach (var entity in entities)
                _dbSet.Add(entity);

            return await _dbContex.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            return await _dbContex.SaveChangesAsync() > 0;
        }

        public async Task<int> UpdateAsync(params TEntity[] entities)
        {
            foreach (var entity in entities)
                _dbSet.Update(entity);

            return await _dbContex.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            return await _dbContex.SaveChangesAsync() > 0;
        }

        public async Task<int> DeleteAsync(params TEntity[] entities)
        {
            _dbSet.RemoveRange(entities);
            return await _dbContex.SaveChangesAsync();
        }
    }
}