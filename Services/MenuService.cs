using Labb1_ASP.NET_API.Models;
using Labb1_ASP.NET_API.Models.DTOs.Menu;
using Labb1_ASP.NET_API.Repositories.IRepositories;
using Labb1_ASP.NET_API.Services.IServices;

namespace Labb1_ASP.NET_API.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }


        public async Task<IEnumerable<ShowMenuDTO>> GetAllMenusAsync()
        {
            var allMenus = await _menuRepository.GetAllMenusAsync();

            return allMenus.Select(x => new ShowMenuDTO
            {
                Id = x.Id,
                FoodName = x.FoodName,
                Price = x.Price,
                IsAvailable = x.IsAvailable,
            });
        }

        public async Task<ShowMenuDTO> GetMenuByIdAsync(int id)
        {
            var existingMenu = await _menuRepository.GetMenuByIdAsync(id);

            return new ShowMenuDTO
            {
                Id = existingMenu.Id,
                FoodName = existingMenu.FoodName,
                Price = existingMenu.Price,
                IsAvailable = existingMenu.IsAvailable,
            };
        }
        public async Task AddMenuAsync(CreateMenuDTO menu)
        {
            await _menuRepository.AddMenuAsync(new Menu 
            { 
                FoodName = menu.FoodName, 
                Price = menu.Price, 
                IsAvailable = menu.IsAvailable 
            });
        }

        public async Task EditMenuAsync(EditMenuDTO menuDto, int id)
        {
            var existingMenu = await _menuRepository.GetMenuByIdAsync(id);

            if (!string.IsNullOrEmpty(menuDto.FoodName))
            {
                existingMenu.FoodName = menuDto.FoodName;
            }
            if (menuDto.Price.HasValue) 
            {
                existingMenu.Price = menuDto.Price.Value;
            }
            if (menuDto.IsAvailable.HasValue)
            {
                existingMenu.IsAvailable = menuDto.IsAvailable.Value;
            }

            await _menuRepository.EditMenuAsync(existingMenu);
        }
        public async Task DeleteMenuAsync(int id)
        {
            await _menuRepository.DeleteMenuAsync(id);
        }
    }
}
