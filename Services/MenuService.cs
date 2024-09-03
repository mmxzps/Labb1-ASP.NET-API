﻿using Labb1_ASP.NET_API.Models;
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
            if (existingMenu == null)
            {
                throw new KeyNotFoundException($"Menu item with Id.{id} was not found!");
            }
            return new ShowMenuDTO
            {
                Id = existingMenu.Id,
                FoodName = existingMenu.FoodName,
                Price = existingMenu.Price,
                IsAvailable = existingMenu.IsAvailable,
            };
        }

        public async Task AddMenuAsync(CreateMenuDTO menuDto)
        {
            if (menuDto.Price <= 0 || menuDto.Price == null)
            {
                throw new InvalidOperationException($"Price cant be empty and must be larger than 0!");
            }
            await _menuRepository.AddMenuAsync(new Menu
            {
                FoodName = menuDto.FoodName,
                Price = menuDto.Price,
                IsAvailable = menuDto.IsAvailable
            });
        }

        public async Task EditMenuAsync(EditMenuDTO menuDto, int id)
        {
            var existingMenu = await _menuRepository.GetMenuByIdAsync(id);
            if (existingMenu == null)
            {
                throw new KeyNotFoundException($"Menu item with Id.{id} was not found!");
            }
            
            if(string.IsNullOrEmpty(menuDto.FoodName))
            {
                throw new InvalidDataException($"Foodname cant be empty!");
            }
            existingMenu.FoodName = menuDto.FoodName;

            if(menuDto.Price <= 0 || menuDto.Price == null)
            {
                throw new InvalidDataException($"Price cant be empty and must be larger than 0!");
            }
            existingMenu.Price = menuDto.Price;

            existingMenu.IsAvailable = menuDto.IsAvailable;

            await _menuRepository.EditMenuAsync(existingMenu);
        }

        public async Task DeleteMenuAsync(int id)
        {
            var existingMenu = await _menuRepository.GetMenuByIdAsync(id);
            if (existingMenu == null)
            {
                throw new KeyNotFoundException($"Menu item with Id.{id} was not found!");
            }

            await _menuRepository.DeleteMenuAsync(existingMenu.Id);
        }
    }
}
