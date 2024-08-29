using Labb1_ASP.NET_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb1_ASP.NET_API.Data
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Booking> Bookings { get; set; }

    }
}
