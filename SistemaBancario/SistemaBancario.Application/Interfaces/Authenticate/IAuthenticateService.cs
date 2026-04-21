using SistemaBancario.Domain.Entidades.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Application.Interfaces.Authenticate
{
    public interface IAuthenticateService
    {
        Task<UsersInfo> AutenticarAsync(string cpf, string senha);
        public string GerarToken(string nome, string email, string cpf);
    }
}
