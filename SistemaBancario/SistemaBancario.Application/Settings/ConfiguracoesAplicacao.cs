using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Application.Settings
{
    public class ConfiguracoesAplicacao : IConfiguracoesAplicacao
    {
        public string JwtSecretKey { get; set; } = default!;
        public string JwtIssuer { get; set; } = default!;
        public string JwtAudience { get; set; } = default!;
        public string DatabaseConnection { get; set; } = default!;
    }
}
