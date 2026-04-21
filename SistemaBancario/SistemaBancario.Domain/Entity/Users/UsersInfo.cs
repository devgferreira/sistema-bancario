using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using BCrypt.Net;
using SistemaBancario.Domain.ValueObjects;
namespace SistemaBancario.Domain.Entidades.Users
{
    public class UsersInfo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Cpf Cpf { get; set; }
        public Email Email { get; set; }
        public Senha Senha { get; set; }


        public UsersInfo Create(string nome, string cpf, string email, string senha, string confirmarSenha)
        {
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(cpf) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                throw new ArgumentException("Todos os campos são obrigatórios.");
            }

            var userInfo = new UsersInfo
            {
                Nome = nome,
                Cpf = Cpf.Criar(cpf),
                Email = Email.Criar(email),
                Senha = Senha.Criar(senha, confirmarSenha)
            };
            return userInfo;
        }

       

     

     
    }
}
