using System.Security.Claims;

namespace AspBlog.API.Controllers
{
    public static class ControllerExtensions
    {
        public static int GetId(this ClaimsPrincipal claimsPrincipal)
        {
            var id_st = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? throw new ArgumentException("Name identifier (User ID) is NULL."); ;


            return int.TryParse(id_st, out var id)
                ? id
                : throw new ArgumentException("Name identifier (User ID) is not in the expected format.");
        }

        public static string GetUserName(this ClaimsPrincipal claimsPrincipal)
            => claimsPrincipal.FindFirstValue(ClaimTypes.Name)
            ?? throw new ArgumentException("Name (Username) is NULL.");

        public static string GetRoleName(this ClaimsPrincipal claimsPrincipal)
            => claimsPrincipal.FindFirstValue(ClaimTypes.Role)
            ?? throw new ArgumentException("Role is NULL.");
    }
}