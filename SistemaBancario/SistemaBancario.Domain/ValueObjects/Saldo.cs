using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Domain.ValueObjects
{
    public class Saldo
    {
        public double Valor { get; private set; }

        public static Saldo Criar(double valor)
        {
            if (!SaldoValido(valor))
            {
                throw new ArgumentException("O saldo não pode ser negativo.");
            }
            return new Saldo
            {
                Valor = valor
            };
        }

        private bool SaldoValido(double valor)
        {
            if (valor < 0)
            {
                return false;
            }
            return true;
        }
    }
}
