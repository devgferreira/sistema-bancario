using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Application.Interfaces.Authenticate
{
    public interface IAuthenticateService
    {
        Task<bool> AutenticarAsync(string cpf, string senha);
        public string GerarToken(string nome, string email, string cpf);
    }
}
