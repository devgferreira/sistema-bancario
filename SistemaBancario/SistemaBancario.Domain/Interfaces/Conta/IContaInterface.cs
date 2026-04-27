using SistemaBancario.Domain.Entity.Conta;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Domain.Interfaces.Conta
{
    public interface IContaInterface
    {
        Task CriarConta(ContaInfo conta);
        Task<List<ContaInfo>> BuscarConta(Guid contaId, int usertId);
        Task AtualizarConta(ContaInfo conta, Guid contaId, int usertId);
        Task DeletarConta (Guid contaId, int usertId);
    }
}
