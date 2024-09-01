using Labb1_ASP.NET_API.Models;
using Labb1_ASP.NET_API.Models.DTOs;
using Labb1_ASP.NET_API.Repositories.IRepositories;
using Labb1_ASP.NET_API.Services.IServices;

namespace Labb1_ASP.NET_API.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;
        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public async Task<IEnumerable<ShowTableDTO>> GetAllTableAsync()
        {
            var tableList = await _tableRepository.GetAllTableAsync();

            return tableList.Select(t => new ShowTableDTO
            {
                Id = t.Id,
                TableNumber = t.TableNumber,
                TableSeats = t.TableSeats
            }).ToList();
        }

        public async Task<ShowTableDTO> GetTableByIdAsync(int id)
        {
            var existingTable = await _tableRepository.GetTableByIdAsync(id);
            return new ShowTableDTO
            {
                Id = existingTable.Id,
                TableNumber = existingTable.TableNumber,
                TableSeats = existingTable.TableSeats
            };
        }

        public async Task AddTableAsync(EditTableDTO tableDto)
        {
            var addTable = new Table
            {
                TableNumber = tableDto.TableNumber,
                TableSeats = tableDto.TableSeats
            };
            await _tableRepository.AddTableAsync(addTable);
        }


        public async Task EditTableAsync(EditTableDTO tableDto, int tableId)
        {
            var existingTable = await _tableRepository.GetTableByIdAsync(tableId);

            existingTable.TableNumber = tableDto.TableNumber;
            existingTable.TableSeats = tableDto.TableSeats;

            await _tableRepository.EditTableAsync(existingTable);
        }

        public async Task DeleteTableAsync(int id)
        {
            await _tableRepository.DeleteTableAsync(id);
        }
    }
}
