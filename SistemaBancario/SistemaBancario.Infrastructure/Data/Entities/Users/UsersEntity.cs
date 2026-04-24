using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Infrastructure.Data.Entities.Users
{
    public class UsersEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
    }
}
