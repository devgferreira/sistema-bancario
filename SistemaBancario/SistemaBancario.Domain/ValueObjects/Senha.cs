using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SistemaBancario.Domain.ValueObjects
{
    public class Senha
    {
        public string Hash { get; private set; }

        public Senha Criar(string senha, string confirmarSenha)
        {
            if(!ConfirmarSenha(senha, confirmarSenha))
            {
                throw new ArgumentException("As senhas não coincidem.");
            }

            if (!SenhaValida(senha))
            {
                throw new ArgumentException("Senha deve conter pelo menos 8 caracteres, incluindo letras maiúsculas, minúsculas, números e caracteres especiais.");
            }
            var result = new Senha
            {
                Hash = BCrypt.Net.BCrypt.HashPassword(senha)
            };
            return result;
        }

        public bool VerificarSenha(string senhaDigitada)
        {
            return BCrypt.Net.BCrypt.Verify(senhaDigitada, Hash);
        }

        public bool ConfirmarSenha(string senhaDigitada, string confirmarSenha)
        {
            if (senhaDigitada != confirmarSenha)
            {
                return false;
            }
            return true;
        }

        private bool SenhaValida(string senha)
        {
            var pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$";
            return Regex.IsMatch(senha, pattern);
        }
    }
}
