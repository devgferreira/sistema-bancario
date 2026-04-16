using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Application.Interfaces.Authenticate
{
    public interface IAuthenticateService
    {
        Task<bool> AutenticarAsync(string email, string senha);
        public string GerarToken(string nome, string email, string cpf);
    }
}
