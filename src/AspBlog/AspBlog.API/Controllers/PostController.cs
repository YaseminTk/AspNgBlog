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
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateAsync([FromBody] PostUpdateDto post)
        {
            try
            {
                post.ChangedById = User.GetId();
                return await postService.UpdateAsync(post) ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
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