using BusinessLayer.Services;
using DataLayer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;

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

        [HttpPost("Login")]
            
        public async Task<IActionResult> Login([FromBody]LoginRequestDTO loginRequest)
        {
            var result = await _userService.Login(loginRequest.email, loginRequest.password);
            if(result != null)
            {
                return Ok(result);
            }
            return StatusCode(500);

        }

        [HttpPost("AddUser")]

        public async Task<IActionResult> AddUser([FromBody]UserRequestDTO user)
        {
            var result = await _userService.AddUserAsync(user);

            return Ok(result);
        }

    }
}
