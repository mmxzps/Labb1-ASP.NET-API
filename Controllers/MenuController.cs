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
            return Ok(menuList);
        }

        [HttpGet("GetAllMenuItemById/{menuId}")]
        public async Task<ActionResult<ShowMenuDTO>> GetAllMenuItemById(int menuId)
        {
            var menu = await _menuService.GetMenuByIdAsync(menuId);
            return Ok(menu);
        }

        [HttpPost("AddMenuItem")]
        public async Task<IActionResult> AddMenuItem(CreateMenuDTO menuDto)
        {
            await _menuService.AddMenuAsync(menuDto);
            return Ok();
        }

        [HttpPut("EditMenuItem/{menuId}")]
        public async Task<IActionResult> EditMenuItem(EditMenuDTO menudto, int menuId)
        {
            await _menuService.EditMenuAsync(menudto, menuId);
            return Ok();
        }

        [HttpDelete("DeleteMenuItem/{menuId}")]
        public async Task<IActionResult> DeleteMenuItem(int menuId)
        {
            await _menuService.DeleteMenuAsync(menuId);
            return Ok();
        }
    }
}
