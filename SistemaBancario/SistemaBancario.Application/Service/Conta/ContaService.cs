using SistemaBancario.Application.DTO.Conta;
using SistemaBancario.Application.Interfaces.Conta;
using SistemaBancario.Domain.Entidades.Users;
using SistemaBancario.Domain.Entity.Conta;
using SistemaBancario.Domain.Enums;
using SistemaBancario.Domain.Interfaces.Conta;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Application.Service.Conta
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _contaRepository;

        public ContaService(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public async Task AtualizarConta(AtualizarContaDTO atualizarContaDTO, Guid id, int userId)
        {

            var contaInfo = await ValidarSeContaExiste(id, userId);

            var conta = ContaInfo.Criar(userId, atualizarContaDTO.Saldo, ((int)contaInfo.Status));

            await _contaRepository.AtualizarConta(conta, id, userId);
        }

        public async Task<List<ContaDTO>> BuscarContas(Guid? contaId, int userId)
        {
            var contas = await _contaRepository.BuscarConta(contaId, userId);

            var conta = contas.Select(c => new ContaDTO
            {
                Id = c.Id,
                UserId = c.UserId,
                Saldo = c.Saldo.Valor,
                Status = c.Status
            }).ToList();    

            return conta;

        }

        public async Task CriarConta(CriarContaDTO criarContaDTO, int userId)
        {

            var conta = ContaInfo.Criar(userId, criarContaDTO.Saldo, status: 0);
            await _contaRepository.CriarConta(conta);
        }

        public async Task DeletarConta(Guid id, int userId)
        {
            await ValidarSeContaExiste(id, userId);
            await _contaRepository.DeletarConta(id, userId);
        }

        private async Task<ContaInfo> ValidarSeContaExiste(Guid id, int userId)
        {
            var result = await _contaRepository.BuscarConta(id, userId);
            if (result.Count == 0)
            {
                throw new Exception("Conta não encontrada.");
            }
            return result.FirstOrDefault();
        }
    }
}
