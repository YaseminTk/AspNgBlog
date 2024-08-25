namespace AspBlog.Abstractions.Services
{
    public interface IBaseService<TEntity, TDto, TCreateDto, TUpdateDto>
    {
        public Task<IEnumerable<TDto>> GetAllAsync();

        public Task<TDto?> GetByIdAsync(int id);

        public Task<bool> CreateAsync(TCreateDto dto);

        public Task<int> CreateAsync(params TCreateDto[] dtos);

        public Task<bool> UpdateAsync(TUpdateDto dto);

        public Task<int> UpdateAsync(params TUpdateDto[] dtos);

        public Task<bool> DeleteAsync(int id);

        public Task<int> DeleteAsync(params int[] ids);
    }
}