using Labb1_ASP.NET_API.Data;
using Labb1_ASP.NET_API.Models;
using Labb1_ASP.NET_API.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Labb1_ASP.NET_API.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly RestaurantDbContext _context;
        public MenuRepository(RestaurantDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Menu>> GetAllMenusAsync()
        {
            return await _context.Menu.ToListAsync();
        }

        public async Task<Menu> GetMenuByIdAsync(int id)
        {
            return await _context.Menu.FindAsync(id);
        }

        public async Task AddMenuAsync(Menu menu)
        {
            await _context.Menu.AddAsync(menu);
            await _context.SaveChangesAsync();
        }

        public async Task EditMenuAsync(Menu menu)
        {
            _context.Menu.Update(menu);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMenuAsync(int id)
        {
            var deleteMenu = await _context.Menu.FindAsync(id);
            _context.Menu.Remove(deleteMenu);
            await _context.SaveChangesAsync();
        }
    }
}
