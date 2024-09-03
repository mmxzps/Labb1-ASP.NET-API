using Labb1_ASP.NET_API.Models;
using Labb1_ASP.NET_API.Models.DTOs.Table;

namespace Labb1_ASP.NET_API.Services.IServices
{
    public interface ITableService
    {
        Task<IEnumerable<ShowTableDTO>> GetAllTableAsync();
        Task<ShowTableDTO> GetTableByIdAsync(int id);
        Task AddTableAsync(EditTableDTO table);
        Task EditTableAsync(EditTableDTO table, int tableId);
        Task DeleteTableAsync(int id);
    }
}
