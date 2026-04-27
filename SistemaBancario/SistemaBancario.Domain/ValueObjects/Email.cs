using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SistemaBancario.Domain.ValueObjects
{
    public class    Email
    {
        public string Valor { get; private set; }

        public static Email Criar(string email)
        {
            if (!EmailValido(email))
            {
                throw new ArgumentException("O email fornecido é inválido.");
            }
            return new Email
            {
                Valor = email
            }; ;
        }


        private static bool EmailValido(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
