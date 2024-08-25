namespace AspBlog.Abstractions.Repositories
{
    public interface IUserRepository<TUser> : IBaseRepository<TUser>
    {
        public Task<TUser?> GetByUserNameAsync(string userName);
    }
}