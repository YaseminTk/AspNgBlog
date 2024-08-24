using AspBlog.Abstractions.Services.DTOs.Post;
using AspBlog.Domain.Entities;
using AutoMapper;

namespace AspBlog.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PostCreateDto, Post>();
            CreateMap<PostUpdateDto, Post>();

            CreateMap<Post, PostDto>();
            CreateMap<PostInfo, PostInfoDto>();
        }
    }
}