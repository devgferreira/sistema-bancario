using Microsoft.AspNetCore.Mvc;
using SistemaBancario.Application.DTO.Conta;
using SistemaBancario.Application.DTO.Users;
using SistemaBancario.Application.Interfaces.Conta;
using SistemaBancario.Application.Interfaces.Users;

namespace SistemaBancario.API.Controllers.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {
      
       private readonly IContaService _contaService;
        public ContaController(IContaService contaService)
        {
            _contaService = contaService;
        }
        [HttpPost]
        public async Task<IActionResult> CriarConta([FromBody] CriarContaDTO request)
        {
            try
            {
                await _contaService.CriarConta(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarConta([FromBody] AtualizarContaDTO request, [FromQuery] Guid id, [FromQuery] int userId)
        {
            try
            {
                await _contaService.AtualizarConta(request, id, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarConta([FromQuery] Guid id, [FromQuery] int userId)
        {
            try
            {
                await _contaService.DeletarConta(id, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> BuscarContas([FromQuery] Guid? contaId, [FromQuery] int userId)
        {
            try
            {
                var contas = await _contaService.BuscarContas(contaId, userId);
                return Ok(contas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
