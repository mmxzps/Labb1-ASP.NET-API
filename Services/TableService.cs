﻿using Labb1_ASP.NET_API.Models;
using Labb1_ASP.NET_API.Models.DTOs.Table;
using Labb1_ASP.NET_API.Repositories.IRepositories;
using Labb1_ASP.NET_API.Services.IServices;

namespace Labb1_ASP.NET_API.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;
        private readonly IBookingRepository _bookingRepository;
        public TableService(ITableRepository tableRepository, IBookingRepository bookingRepository)
        {
            _tableRepository = tableRepository;
            _bookingRepository = bookingRepository;
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
            if (existingTable == null)
            {
                throw new KeyNotFoundException($"Table with Id.{id} was not found!");
            }
            return new ShowTableDTO
            {
                Id = existingTable.Id,
                TableNumber = existingTable.TableNumber,
                TableSeats = existingTable.TableSeats
            };
        }

        public async Task<List<ShowTableDTO>> GetAllFreeTables(DateTime startTime, int amountFuests)
        {
            var allTables = await _tableRepository.GetAllTableAsync();
            List<ShowTableDTO> freeTables = new List<ShowTableDTO>();
            var endTime = startTime.AddHours(2);

            foreach (var table in allTables)
            {
                if(table.TableSeats == amountFuests)
                {
                    var isBusy = await _bookingRepository.IsTableBusyAsync(table.Id, startTime, endTime);
                    if (!isBusy)
                    {
                        freeTables.Add(new ShowTableDTO
                        {
                            Id=table.Id,
                            TableNumber = table.TableNumber,
                            TableSeats = table.TableSeats,
                        });
                    }
                }
            }
            return freeTables;
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
            var tableToUpdate = await _tableRepository.GetTableByIdAsync(tableId);
            var allExistingTables = await _tableRepository.GetAllTableAsync();

            if (allExistingTables.Any(t => t.TableNumber == tableToUpdate.TableNumber && t.Id == tableId))
            {
                tableToUpdate.TableNumber = tableDto.TableNumber;
                tableToUpdate.TableSeats = tableDto.TableSeats;

                await _tableRepository.EditTableAsync(tableToUpdate);

            }
            if (allExistingTables.Any(t => t.TableNumber == tableToUpdate.TableNumber && t.Id != tableId))
            {
                throw new InvalidOperationException($"Table with number {tableDto.TableNumber} already exist!");
            }
        }

        public async Task DeleteTableAsync(int id)
        {
            var existingTable = await _tableRepository.GetTableByIdAsync(id);
            if (existingTable == null)
            {
                throw new KeyNotFoundException($"Table with Id.{id} was not found!");
            }
            await _tableRepository.DeleteTableAsync(existingTable.Id);
        }
    }
}
