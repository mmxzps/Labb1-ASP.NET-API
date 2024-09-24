using Labb1_ASP.NET_API.Data;
using Labb1_ASP.NET_API.Models;
using Labb1_ASP.NET_API.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Labb1_ASP.NET_API.Repositories
{
    public class UserRepository : IUserRepository

    {
        private readonly RestaurantDbContext _restaurantDbContext;
        public UserRepository(RestaurantDbContext restaurantDbContext)
        {
            _restaurantDbContext = restaurantDbContext;
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _restaurantDbContext.Users.SingleOrDefaultAsync(u=>u.Email == email);
            return user;
        }

        public async Task RegisterUserAsync(User user)
        {
            _restaurantDbContext.Users.Add(user);
            await _restaurantDbContext.SaveChangesAsync();
        }
    }
}
