using SistemaBancario.Domain.Entity.Conta;
using SistemaBancario.Domain.ValueObjects;
using SistemaBancario.Infrastructure.Data.Entities.Conta;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Infrastructure.Data.Mapping.Conta
{
    public static class ContaMapper
    {

        public static ContaEntity MapToContaEntity(this ContaInfo request)
        {
            return new ContaEntity
            {
                id = request.Id,
                UserId = request.UserId,
                Saldo = request.Saldo.Valor,
                Status = (int)request.Status
            };
        }

        public static ContaInfo MapToContaInfo(this ContaEntity entity)
        {
            return new ContaInfo
            {
                Id = entity.id,
                UserId = entity.UserId,
                Saldo = Saldo.Criar(entity.Saldo),
                Status = (Domain.Enums.Status)entity.Status
            };
        }
    }
}
