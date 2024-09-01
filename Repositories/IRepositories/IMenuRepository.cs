using Labb1_ASP.NET_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labb1_ASP.NET_API.Repositories.IRepositories
{
    public interface IMenuRepository
    {
        Task<IEnumerable<Menu>> GetAllMenusAsync();
        Task <Menu> GetMenuByIdAsync(int id);
        Task AddMenuAsync(Menu menu);
        Task EditMenuAsync(Menu menu);
        Task  DeleteMenuAsync(int id);
    }
}
