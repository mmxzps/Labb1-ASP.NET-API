using Labb1_ASP.NET_API.Models.DTOs.User;

namespace Labb1_ASP.NET_API.Services.IServices
{
    public interface IUserService
    {
        Task RegisterUserAsync(RegisterUserDTO userDTO);

        Task<string> LoginUserAsync(LoginUserDTO userDTO);
    }
}
