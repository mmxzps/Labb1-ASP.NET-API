using Labb1_ASP.NET_API.Models;
using Labb1_ASP.NET_API.Models.DTOs.Menu;

namespace Labb1_ASP.NET_API.Services.IServices
{
    public interface IMenuService
    {
        Task<IEnumerable<ShowMenuDTO>> GetAllMenusAsync();
        Task<ShowMenuDTO> GetMenuByIdAsync(int id);
        Task AddMenuAsync(CreateMenuDTO menu);
        Task EditMenuAsync(EditMenuDTO menu, int id);
        Task DeleteMenuAsync(int id);
    }
}
