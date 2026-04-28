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

        public static Saldo DescontarSaldo(double valorDescontado, Saldo saldoAtual)
        {
            var novoValor = saldoAtual.Valor - valorDescontado;
            if (!SaldoValido(novoValor))
            {
                throw new ArgumentException("O saldo não pode ser negativo.");
            }
            return new Saldo
            {
                Valor = novoValor
            };
        }
        public static Saldo AdicionarSaldo(double valorAdicionado, Saldo saldoAtual)
        {
            var novoValor = saldoAtual.Valor + valorAdicionado;
            if (!SaldoValido(novoValor))
            {
                throw new ArgumentException("O saldo não pode ser negativo.");
            }
            return new Saldo
            {
                Valor = novoValor
            };
        }

        private static bool SaldoValido(double valor)
        {
            if (valor < 0)
            {
                return false;
            }
            return true;
        }
    }
}
