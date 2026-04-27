using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Infrastructure.Data.Entities.Conta
{
    public class ContaEntity
    {
        public Guid id { get; set; }
        public int UserId { get; set; }
        public double Saldo { get; set; }
        public int Status { get; set; }
    }
}
