﻿using AspBlog.Abstractions.DTOs.Post;
using AspBlog.Abstractions.Repositories;
using AspBlog.Abstractions.Services;
using AspBlog.Domain.Entities;
using AutoMapper;

namespace AspBlog.Application.Services
{
    public class PostService(IPostRepository<Post, PostInfo> repository, IMapper mapper) 
        : BaseService<Post, IPostRepository<Post, PostInfo>, PostDto, PostCreateDto, PostUpdateDto>(repository, mapper), IPostService<Post>
    {
        public async Task<IEnumerable<PostInfoDto>> GetAllInfosAsync()
        {
            var entities = await _repository.GetAllInfosAsync();
            return _mapper.Map<IEnumerable<PostInfoDto>>(entities);
        }

        public async Task<PostInfoDto?> GetInfoByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity is null ? null : _mapper.Map<PostInfoDto>(entity);
        }
    }
}