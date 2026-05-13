using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaBancario.Application.DTO.Conta;
using SistemaBancario.Application.Interfaces.Conta;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SistemaBancario.API.Controllers.Users
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _contaService;

        public ContaController(IContaService contaService)
        {
            _contaService = contaService;
        }

        private int ObterUserIdDoToken()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(userIdClaim))
                throw new UnauthorizedAccessException("Token inválido");

            if (!int.TryParse(userIdClaim, out var userId))
                throw new UnauthorizedAccessException("Token inválido");

            return userId;
        }

        [HttpPost]
        public async Task<IActionResult> CriarConta([FromBody] CriarContaDTO request)
        {
            try
            {
                var userId = ObterUserIdDoToken();
                await _contaService.CriarConta(request, userId);

                return Ok();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarConta(
            [FromBody][Required] AtualizarContaDTO request,
            [FromQuery][Required] Guid id)
        {
            try
            {
                var userId = ObterUserIdDoToken();

                await _contaService.AtualizarConta(request, id, userId);

                return Ok();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarConta([FromQuery] Guid id)
        {
            try
            {
                var userId = ObterUserIdDoToken();

                await _contaService.DeletarConta(id, userId);

                return Ok();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> BuscarContas([FromQuery] Guid? contaId)
        {
            try
            {
                var userId = ObterUserIdDoToken();

                var contas = await _contaService.BuscarContas(contaId, userId);

                return Ok(contas);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}