using SistemaBancario.Domain.Enums;
using SistemaBancario.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Domain.Entity.Conta
{
    internal class ContaInfo
    {
        public Guid Id { get; set; } 
        public int UsertId { get; set; }
        public Saldo Saldo { get; set; }
        public Status Status { get; set; }


        public static ContaInfo Criar(int usertId, double saldo, int status)
        {
            var contaInfo = new ContaInfo
            {
                Id = Guid.NewGuid(),
                UsertId = usertId,
                Saldo = Saldo.Criar(saldo),
                Status = (Status)status
            };
            return contaInfo;
        }

    }
}
