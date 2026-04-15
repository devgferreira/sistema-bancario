using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SistemaBancario.Domain.Entidades.Users
{
    public class UsersInfo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }



        public UsersInfo Create(string nome, string cpf, string email, string senha)
        {
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(cpf) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                throw new ArgumentException("Todos os campos são obrigatórios.");
            }


            if (!EmailValido(email))
            {
                throw new ArgumentException("O email fornecido é inválido.");
            }
            if (!CpfValido(cpf))
            {
                throw new ArgumentException("O CPF fornecido é inválido");
            }
            if (!SenhaValida(senha))
            {
                throw new ArgumentException("A senha deve conter pelo menos 8 caracteres, incluindo letras maiúsculas, minúsculas, números e caracteres especiais.");
            }

            var userInfo = new UsersInfo
            {
                Nome = nome,
                Cpf = cpf,
                Email = email,
                Senha = senha
            };
            return userInfo;
        }

        private bool EmailValido(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private bool CpfValido(string cpf)
        {
            if (cpf.Length != 11)
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
