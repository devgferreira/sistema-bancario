using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Domain.ValueObjects
{
    public class Cpf
    {
        public string Valor { get; private set; }

        public static Cpf Criar(string cpf)
        {
            if (!CpfValido(cpf))
            {
                throw new ArgumentException("O CPF fornecido é inválido");
            }

            return new Cpf
            {
                Valor = cpf
            };
        }

        private static bool CpfValido(string cpf)
        {
            if (cpf.Length != 11)
            {
                return false;
            }
            return true;
        }
    }
}
