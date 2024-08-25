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

        public async Task<bool> Create(TCreateDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            return await _repository.CreateAsync(entity);
        }

        public async Task<int> Create(params TCreateDto[] dtos)
        {
            var entities = _mapper.Map<TEntity[]>(dtos);
            return await _repository.CreateAsync(entities);
        }

        public async Task<bool> Update(TUpdateDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            return await _repository.UpdateAsync(entity);
        }

        public async Task<int> Update(params TUpdateDto[] dtos)
        {
            var entities = _mapper.Map<TEntity[]>(dtos);
            return await _repository.UpdateAsync(entities);
        }
    }
}