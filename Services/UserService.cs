using BCrypt.Net;
using Labb1_ASP.NET_API.Models;
using Labb1_ASP.NET_API.Models.DTOs.User;
using Labb1_ASP.NET_API.Repositories.IRepositories;
using Labb1_ASP.NET_API.Services.IServices;
using Labb1_ASP.NET_API.Utilitys;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Labb1_ASP.NET_API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
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




        public async Task<string> LoginUserAsync(LoginUserDTO userDTO)
        {
            var findUser = await _userRepository.GetUserByEmailAsync(userDTO.Email);
            if(findUser == null)
            {
                throw new KeyNotFoundException($"Cant find user with email:{userDTO.Email}");
            }

            //controll if email or pass is correct
            if (Verification.CheckEmailAndPassword(findUser, userDTO.Password, findUser.PasswordHash))
            {
                throw new InvalidOperationException("Invalid email or password!");
            };

            //generate jwt token and returns it
            var token = Verification.GenerateJwtToken(findUser, _configuration);
            return token ;
        }
    }
}
