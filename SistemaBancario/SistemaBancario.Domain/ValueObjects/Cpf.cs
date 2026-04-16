using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Domain.ValueObjects
{
    public class Cpf
    {
        public string Valor { get; set; }


        public Cpf Criar(string cpf)
        {
            if (!CpfValido(cpf))
            {
                throw new ArgumentException("O CPF fornecido é inválido");
            }
            return new Cpf
            {
                Valor = cpf
            }; ;
        }

        private bool CpfValido(string cpf)
        {
            if (cpf.Length != 11)
            {
                return false;
            }
            return true;
        }
    }
}
