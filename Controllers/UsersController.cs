using Labb1_ASP.NET_API.Models.DTOs.User;
using Labb1_ASP.NET_API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb1_ASP.NET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserDTO registerUserDTO)
        {
            try
            {
                await _userService.RegisterUserAsync(registerUserDTO);

            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }

            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDTO loginUserDTO)
        {
            try
            {
                var token = await _userService.LoginUserAsync(loginUserDTO);
                return Ok(new { token } );

            }catch (KeyNotFoundException ex)
            {

                return NotFound(ex.Message);

            }catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
