using AspBlog.Abstractions.DTOs.User;
using AspBlog.Abstractions.Services;
using AspBlog.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(ILogger<UserController> logger, IUserService<User> userService) : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAsync([FromQuery] string? userName = null)
        {
            try
            {
                if (userName is null)
                {
                    var users = await userService.GetAllAsync();
                    return Ok(users);
                }
                else
                {
                    var user = await userService.GetByUserNameAsync(userName);
                    return user is null ? NotFound() : Ok(user);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var user = await userService.GetByIdAsync(id);
                return user is null ? NotFound() : Ok(user);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}