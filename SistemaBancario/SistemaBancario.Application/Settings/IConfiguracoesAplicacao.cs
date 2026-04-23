using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Application.Settings
{
    public interface IConfiguracoesAplicacao
    {
        string JwtSecretKey { get; }
        string JwtIssuer { get; }
        string JwtAudience { get; }
        string DatabaseConnection { get; }
    }
}
