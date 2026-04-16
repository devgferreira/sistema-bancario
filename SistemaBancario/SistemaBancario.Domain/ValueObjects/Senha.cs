using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SistemaBancario.Domain.ValueObjects
{
    public class Senha
    {
        public string Hash { get; private set; }

        public Senha Criar(string hash)
        {
            if (!SenhaValida(hash))
            {
                throw new ArgumentException("Senha deve conter pelo menos 8 caracteres, incluindo letras maiúsculas, minúsculas, números e caracteres especiais.");
            }
            var senha = new Senha
            {
                Hash = BCrypt.Net.BCrypt.HashPassword(hash)
            };
            return senha;
        }

        public bool VerificarSenha(string senhaDigitada)
        {
            return BCrypt.Net.BCrypt.Verify(senhaDigitada, Hash);
        }

        private bool SenhaValida(string senha)
        {
            var pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$";
            return Regex.IsMatch(senha, pattern);
        }
    }
}
