using SistemaBancario.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Application.DTO.Conta
{
    public class CriarContaDTO
    {
        public int UserId { get; set; }
        public double Saldo { get; set; }
        public Status Status { get; set; }

    }
}
