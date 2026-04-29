using SistemaBancario.Application.DTO.Conta;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Application.Interfaces.Conta
{
    public interface IContaService
    {
        Task CriarConta(CriarContaDTO criarContaDTO);
        Task AtualizarConta(AtualizarContaDTO atualizarContaDTO, Guid id, int userId);
        Task DeletarConta(Guid id, int userId);
        Task<List<ContaDTO>> BuscarContas(Guid id, int userId);
    }
}
