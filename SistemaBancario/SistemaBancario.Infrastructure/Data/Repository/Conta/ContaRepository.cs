using Dapper;
using SistemaBancario.Domain.Entity.Conta;
using SistemaBancario.Domain.Enums;
using SistemaBancario.Domain.Interfaces.Conta;
using SistemaBancario.Domain.ValueObjects;
using SistemaBancario.Infrastructure.Data.Context;
using SistemaBancario.Infrastructure.Data.Entities.Conta;
using SistemaBancario.Infrastructure.Data.Mapping.Conta;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Infrastructure.Data.Repository.Conta
{
    public class ContaRepository : IContaRepository
    {
        private readonly DbContext _context;

        public ContaRepository(DbContext context)
        {
            _context = context;
        }

        public async Task AtualizarConta(ContaInfo conta, Guid contaId, int usertId)
        {
            var sql = "UPDATE Conta SET Saldo = @Saldo, Status = @Status WHERE Id = @Id AND UserId = @UserId";
            await _context.Connection.ExecuteAsync(sql, new
            {
                Id = contaId,
                UserId = usertId,
                Saldo = conta.Saldo.Valor,
                Status = (int)conta.Status
            });
        }

        public async Task<List<ContaInfo>> BuscarConta(Guid contaId, int usertId)
        {
            var sql = "SELECT Id, UserId, Saldo, Status FROM Conta WHERE Id = @Id AND UserId = @UserId";
            var entities = await _context.Connection.QueryAsync<ContaEntity>(sql, new
            {
                Id = contaId,
                UserId = usertId
            });
            var result = new List<ContaInfo>();
            foreach (var entity in entities) 
            {
                result.Add(entity.MapToContaInfo());
            }
            return result;

        }

        public async Task CriarConta(ContaInfo conta)
        {
           var sql = "INSERT INTO Conta ( UserId, Saldo, Status) VALUES (@Id, @UserId, @Saldo, @Status)";

            await _context.Connection.ExecuteAsync(sql, new
            {
                Id = conta.Id,
                UserId = conta.UserId,
                Saldo = conta.Saldo.Valor,
                Status = conta.Status
            });
        }

        public async Task DeletarConta(Guid contaId, int usertId)
        {
            var sql = "DELETE FROM Conta WHERE Id = @Id AND UserId = @UserId";
            await _context.Connection.ExecuteAsync(sql, new
            {
                Id = contaId,
                UserId = usertId
            });
        }
    }
}
