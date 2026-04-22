using Microsoft.AspNetCore.Mvc;
using SistemaBancario.Application.DTO.Users;
using SistemaBancario.Application.Interfaces.Users;

namespace SistemaBancario.API.Controllers.Users
{
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
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

        [HttpPut]
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
