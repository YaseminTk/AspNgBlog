﻿using AspBlog.Abstractions.Services;
using AspBlog.Abstractions.Services.DTOs.Post;
using AspBlog.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AspBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController(ILogger<PostController> logger, IPostService<Post> postService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] bool with_content = false)
        {
            try
            {
                var posts = with_content ? await postService.GetAllAsync() : await postService.GetAllInfosAsync();
                return Ok(posts);
            }              
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] PostCreateDto post)
        {
            try
            {
                return await postService.CreateAsync(post) ? Ok() : BadRequest();
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "{message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] PostUpdateDto post)
        {
            try
            {
                return await postService.UpdateAsync(post) ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                return await postService.DeleteAsync(id) ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromQuery] int[] id)
        {
            try
            {
                return Ok(await postService.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}