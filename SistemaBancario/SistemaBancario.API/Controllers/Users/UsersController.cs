using Microsoft.AspNetCore.Mvc;
using SistemaBancario.Application.DTO.Users;
using SistemaBancario.Application.Interfaces.Users;

namespace SistemaBancario.API.Controllers.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsersLoginRequest request)
        {
            try
            {
                var tokenResponse = await _usersService.Login(request);
                return Ok(tokenResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("registro")]
        public async Task<IActionResult> Registro([FromBody] UsersRegistroRequest request)
        {
            try
            {
                var tokenResponse = await _usersService.Registro(request);
                return Ok(tokenResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
