using BCrypt.Net;
using Labb1_ASP.NET_API.Models;
using Labb1_ASP.NET_API.Models.DTOs.User;
using Labb1_ASP.NET_API.Repositories.IRepositories;
using Labb1_ASP.NET_API.Services.IServices;

namespace Labb1_ASP.NET_API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task RegisterUserAsync(RegisterUserDTO userDTO)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(userDTO.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("This email is already in use!");
            }

            //hashing the password
            string hashPassword = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);
            var registerUser = new User
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                PasswordHash = hashPassword
            };
            await _userRepository.RegisterUserAsync(registerUser);
        }
    }
}
