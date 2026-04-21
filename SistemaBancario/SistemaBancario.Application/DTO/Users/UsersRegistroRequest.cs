using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Application.DTO.Users
{
    public class UsersRegistroRequest
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
        public string Token { get; set; }
    }
}
