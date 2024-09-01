using Labb1_ASP.NET_API.Models;
using Labb1_ASP.NET_API.Models.DTOs;
using Labb1_ASP.NET_API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb1_ASP.NET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly ITableService _tableService;
        public TablesController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet("GetAllTables")]
        public async Task<ActionResult<IEnumerable<Table>>> GetAllTables()
        {
            var allTable = await _tableService.GetAllTableAsync();
            if (allTable == null || !allTable.Any())
            {
                return NotFound(new { Error = "No table found!" });
            }
            return Ok(allTable);
        }

        [HttpGet("GetTableById/{tableId}")]
        public async Task<ActionResult<Table>> GetTableById(int tableId)
        {
            var theTable = await _tableService.GetTableByIdAsync(tableId);
            if ((theTable == null))
            {
                return NotFound(new { Error = $"No table with id.{tableId} found!" });
            }
            return Ok(theTable);
        }

        [HttpPost("AddTable")]
        public async Task<IActionResult> AddTable(EditTableDTO tableDto)
        {
            await _tableService.AddTableAsync(tableDto);
            return Created();
        }

        [HttpPut("EditTable/{tableId}")]
        public async Task<IActionResult> EditTable(EditTableDTO tableDTO, int tableId)
        {
            await _tableService.EditTableAsync(tableDTO, tableId);
            return Ok();
        }

        [HttpDelete("DeleteTable/{tableId}")]
        public async Task<IActionResult> DeleteTable(int tableId)
        {
            await _tableService.DeleteTableAsync(tableId);
            return Ok();
        }
    }
}
