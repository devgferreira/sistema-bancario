using SistemaBancario.Domain.Enums;
using SistemaBancario.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Domain.Entity.Conta
{
    public class ContaInfo
    {
        public Guid Id { get; set; } 
        public int UserId { get; set; }
        public Saldo Saldo { get; set; }
        public Status Status { get; set; }


        public static ContaInfo Criar(int usertId, double saldo, int status)
        {
            if (ValidarContaBloqueada(status))
            {
                throw new InvalidOperationException("Conta bloqueada.");
            }
            var contaInfo = new ContaInfo
            {
                Id = Guid.NewGuid(),
                UserId = usertId,
                Saldo = Saldo.Criar(saldo),
                Status = (Status)status
            };
            return contaInfo;
        }

        private static bool ValidarContaBloqueada(int status)
        {
            if (status == 1)
            {
                return true;
            }
            return false;
        }

    }
}
