using AspBlog.Abstractions.DTOs.Post;
using AspBlog.Abstractions.DTOs.User;
using AspBlog.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AspBlog.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile(PasswordHasher<string> passwordHasher)
        {
            CreateMap<PostCreateDto, Post>();
            CreateMap<PostUpdateDto, Post>();
            CreateMap<UserCreateDto, User>().ForMember(
                user => user.PasswordHash, 
                opt => opt.MapFrom(dto => passwordHasher.HashPassword(dto.UserName, dto.Password)));
            CreateMap<UserUpdateDto, User>();
            CreateMap<LogInUpdateDto, User>().ForMember(
                user => user.PasswordHash,
                opt => opt.MapFrom(dto => passwordHasher.HashPassword(dto.UserName, dto.Password)));
            CreateMap<LogInDto, LogInUpdateDto>();
            CreateMap<RoleUpdateDto, User>();

            CreateMap<Post, PostDto>();
            CreateMap<PostInfo, PostInfoDto>();
            CreateMap<User, UserDto>();
        }
    }
}