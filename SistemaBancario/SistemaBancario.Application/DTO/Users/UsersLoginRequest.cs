using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Application.DTO.Users
{
    public class UsersLoginRequest
    {
        public string Cpf { get; set; }
        public string Senha { get; set; }
    }
}
