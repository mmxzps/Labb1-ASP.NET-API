using Labb1_ASP.NET_API.Models;

namespace Labb1_ASP.NET_API.Repositories.IRepositories
{
    public interface IUserRepository
    {
        Task RegisterUserAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
    }
}
