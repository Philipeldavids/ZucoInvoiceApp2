using BusinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace InvoiceGenAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;

        }

        [HttpGet("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var result = await _userService.Login(email, password);

            return Ok(result);

        }

        [HttpPost("AddUser")]

        public async Task<IActionResult> AddUser(User user, string Password)
        {
            var result = await _userService.AddUserAsync(user, Password);

            return Ok(result);
        }

    }
}
