using Labb1_ASP.NET_API.Models.DTOs.Menu;
using Labb1_ASP.NET_API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb1_ASP.NET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService; 
        }

        [HttpGet("GetAllMenuItems")]
        public async Task<ActionResult<IEnumerable<ShowMenuDTO>>> GetAllMenuItems()
        {
            var menuList = await _menuService.GetAllMenusAsync();
            if(menuList == null || !menuList.Any())
            {
                return NotFound(new { Error = "No menu items found!" });
            }
            return Ok(menuList);
        }


        [HttpGet("GetMenuItemById/{menuId}")]
        public async Task<ActionResult<ShowMenuDTO>> GetMenuItemById(int menuId)
        {
            try
            {
                var menu = await _menuService.GetMenuByIdAsync(menuId);
                return Ok(menu);
            }
            catch (KeyNotFoundException ex) 
            {
                return NotFound($"{ex.Message}");
            }
        }


        [HttpPost("AddMenuItem")]
        public async Task<IActionResult> AddMenuItem(CreateMenuDTO menuDto)
        {
            try
            {
                await _menuService.AddMenuAsync(menuDto);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }


        [HttpPut("EditMenuItem/{menuId}")]
        public async Task<IActionResult> EditMenuItem(EditMenuDTO menudto, int menuId)
        {
            try
            {
                await _menuService.EditMenuAsync(menudto, menuId);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound($"{ex.Message}");
            }
            catch(InvalidDataException ex)
            {
                return BadRequest($"{ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }


        [HttpDelete("DeleteMenuItem/{menuId}")]
        public async Task<IActionResult> DeleteMenuItem(int menuId)
        {
            try
            {
                await _menuService.DeleteMenuAsync(menuId);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound($"{ex.Message}");
            }
        }
    }
}
