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
        [AllowAnonymous]
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
        [AllowAnonymous]
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

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAsync([FromBody] UserCreateDto user)
        {
            try
            {
                return await userService.CreateAsync(user) ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateAsync([FromBody] UserUpdateDto user)
        {
            try
            {
                return await userService.UpdateAsync(user) ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("role")]
        [Authorize(Roles = $"{Role.Admin},{Role.Writer}")]
        public async Task<IActionResult> UpdateAsync([FromBody] RoleUpdateDto update)
        {
            try
            {
                var user_role = User.GetRoleName();
 
                if(update.Role == Role.Admin)
                {
                    if(user_role != Role.Admin)
                        return Unauthorized();
                }                    
                else if(update.Role != Role.Writer && update.Role != Role.User)
                    return BadRequest();

                return await userService.UpdateAsync(update) ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteAsync()
        {
            try
            {
                var user_id = User.GetId();
                return await userService.DeleteAsync(user_id) ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = $"{Role.Admin}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                return await userService.DeleteAsync(id) ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}