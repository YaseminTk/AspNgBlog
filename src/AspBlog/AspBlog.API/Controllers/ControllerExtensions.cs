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
    }
}