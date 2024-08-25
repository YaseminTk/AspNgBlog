using AspBlog.Abstractions.DTOs.User;
using AspBlog.Abstractions.Services;
using AspBlog.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace AspBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService, IUserService<User> userService, IOptions<AuthenticationOptions> AuthOptions) : ControllerBase
    {
        [HttpPost("in")]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn([FromForm] LogInDto logIn)
        {
            if(!await authService.Verify(logIn))
                return Unauthorized();

            var user = await userService.GetByUserNameAsync(logIn.UserName);

            if (user == null)
                return Unauthorized();

            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new (ClaimTypes.Name, user.UserName),
                new (ClaimTypes.Role, user.Role),
                new (ClaimTypes.GivenName, user.FullName)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authOptVal = AuthOptions.Value;
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(authOptVal.ExpiresInMinutes),
                IsPersistent = authOptVal.IsPersistent,
                AllowRefresh = authOptVal.AllowRefresh,
                IssuedUtc = DateTimeOffset.UtcNow,
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return Ok();
        }

        [HttpPost("out")]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }

        [HttpGet("check")]
        public IActionResult Check() => Ok(User?.Identity?.IsAuthenticated ?? false);

        [HttpGet("role")]
        [Authorize]
        public IActionResult GetRole() => Ok(User.GetRoleName());
    }
}