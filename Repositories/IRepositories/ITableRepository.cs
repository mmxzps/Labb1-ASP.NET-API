using Labb1_ASP.NET_API.Models;
using Labb1_ASP.NET_API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Labb1_ASP.NET_API.Repositories.IRepositories
{
    public interface ITableRepository
    {
        Task<IEnumerable<Table>> GetAllTableAsync();
        Task<Table> GetTableByIdAsync(int id);
        Task AddTableAsync(Table table);
        Task EditTableAsync(Table table);
        Task DeleteTableAsync(int id);
    }
}
