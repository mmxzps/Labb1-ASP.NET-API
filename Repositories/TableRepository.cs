using Labb1_ASP.NET_API.Data;
using Labb1_ASP.NET_API.Models;
using Labb1_ASP.NET_API.Models.DTOs;
using Labb1_ASP.NET_API.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Labb1_ASP.NET_API.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly RestaurantDbContext _context;
        public TableRepository(RestaurantDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Table>> GetAllTableAsync()
        {
            var tableList = await _context.Tables.ToListAsync();
            return tableList;
        }

        public async Task<Table> GetTableByIdAsync(int id)
        {
            return await _context.Tables.FindAsync(id);
        }
        public async Task AddTableAsync(Table table)
        {
            await _context.Tables.AddAsync(table);
            await _context.SaveChangesAsync();
        }

        public async Task EditTableAsync(Table table)
        {
             _context.Tables.Update(table);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteTableAsync(int id)
        {
            var existingTable = await _context.Tables.FindAsync(id);
            _context.Tables.Remove(existingTable);
            await _context.SaveChangesAsync();
        }

    }
}
