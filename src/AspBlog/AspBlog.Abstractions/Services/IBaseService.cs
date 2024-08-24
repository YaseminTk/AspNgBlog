using AspBlog.Abstractions.Repositories;

namespace AspBlog.Abstractions.Services
{
    public interface IBaseService<TEntity, TRepository, TDto, TCreateDto, TUpdateDto> where TRepository : IBaseRepository<TEntity>
    {
        public Task<IEnumerable<TDto>> GetAllAsync();

        public Task<TDto?> GetByIdAsync(int id);

        public Task<bool> Create(TCreateDto dto);

        public Task<int> Create(params TCreateDto[] dtos);

        public Task<bool> Update(TUpdateDto dto);

        public Task<int> Update(params TUpdateDto[] dtos);
    }
}