using AspBlog.Abstractions.DTOs.Post;
using AspBlog.Abstractions.Services;
using AspBlog.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController(ILogger<PostController> logger, IPostService<Post> postService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] bool content = false)
        {
            try
            {
                var posts = content ? await postService.GetAllAsync() : await postService.GetAllInfosAsync();
                return Ok(posts);
            }              
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Authorize(Roles = $"{Role.Admin},{Role.Writer}")]
        public async Task<IActionResult> CreateAsync([FromBody] PostCreateDto post)
        {
            try
            {
                post.CreatedById = User.GetId();
                return await postService.CreateAsync(post) ? Ok() : BadRequest();
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "{message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Authorize(Roles = $"{Role.Admin},{Role.Writer}")]
        public async Task<IActionResult> UpdateAsync([FromBody] PostUpdateDto post)
        {
            try
            {
                // check if the post created by the current user
                var current_post = await postService.GetByIdAsync(post.Id);
                if(current_post?.CreatedById != User.GetId())
                    return Unauthorized();

                return await postService.UpdateAsync(post) ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = $"{Role.Admin},{Role.Writer}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                // a writer can delete only own post
                if (User.GetRoleName() == "writer")
                {
                    var current_post = await postService.GetByIdAsync(id);
                    if(current_post?.CreatedById != User.GetId())
                        return Unauthorized();
                }

                return await postService.DeleteAsync(id) ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}