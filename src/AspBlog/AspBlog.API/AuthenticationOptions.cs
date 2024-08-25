namespace AspBlog.API
{
    public class AuthenticationOptions
    {
        public int ExpiresInMinutes { get; init; } = 30;

        public bool IsPersistent { get; init; } = true;

        public bool AllowRefresh { get; init; } = true;
    }
}
