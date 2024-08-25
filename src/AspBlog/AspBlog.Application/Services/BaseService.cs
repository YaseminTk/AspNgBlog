using AspBlog.Abstractions.Repositories;
using AspBlog.Abstractions.Services;
using AspBlog.Abstractions.Services.DTOs.Base;
using AspBlog.Domain.Entities;
using AutoMapper;

namespace AspBlog.Application.Services
{
    public class BaseService<TEntity, TRepository, TDto, TCreateDto, TUpdateDto>(TRepository repository, IMapper mapper) 
        : IBaseService<TEntity, TDto, TCreateDto, TUpdateDto>
        where TEntity : BaseEntity
        where  TRepository : IBaseRepository<TEntity>
        where TDto : BaseDto where TCreateDto : BaseCreateDto where TUpdateDto : BaseUpdateDto
    {
        protected readonly TRepository _repository = repository;

        protected readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public async Task<TDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity is null ? null : _mapper.Map<TDto>(entity);
        }

        public async Task<bool> CreateAsync(TCreateDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            return await _repository.CreateAsync(entity);
        }

        public async Task<int> CreateAsync(params TCreateDto[] dtos)
        {
            var entities = _mapper.Map<TEntity[]>(dtos);
            return await _repository.CreateAsync(entities);
        }

        public async Task<bool> UpdateAsync(TUpdateDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            return await _repository.UpdateAsync(entity);
        }

        public async Task<int> UpdateAsync(params TUpdateDto[] dtos)
        {
            var entities = _mapper.Map<TEntity[]>(dtos);
            return await _repository.UpdateAsync(entities);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entitiy = await _repository.GetByIdAsync(id);
            return entitiy is not null && await _repository.DeleteAsync(entitiy);
        }

        public async Task<int> DeleteAsync(params int[] ids)
        {
#nullable disable
            IEnumerable<TEntity> entities = (await Task.WhenAll(ids
                .Select(async id => await _repository.GetByIdAsync(id))))
                .Where(entity => entity is not null);
# nullable enable

            return await _repository.DeleteAsync(entities.ToArray());
        }
    }
}