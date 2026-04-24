using Microsoft.IdentityModel.Tokens;
using SistemaBancario.Application.Interfaces.Authenticate;
using SistemaBancario.Application.Settings;
using SistemaBancario.Domain.Entidades.Users;
using SistemaBancario.Domain.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
namespace SistemaBancario.Application.Service.Authenticate
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IConfiguracoesAplicacao _configuracao;

        public AuthenticateService(IUsersRepository usersRepository, IConfiguracoesAplicacao configuracao)
        {
            _usersRepository = usersRepository;
            _configuracao = configuracao;
        }

        public async Task<UsersInfo> AutenticarAsync(string cpf, string senha)
        {
            var users = await _usersRepository.BuscarUsuario(null, null, cpf );

            var user = users.FirstOrDefault();
            if (user == null)
            {
                throw new Exception("Usuário não encontrado.");
            }
           
            var senhaValida = user.Senha.VerificarSenha(senha);
            if (!senhaValida)
            {
                throw new ArgumentException("Senha ou Cpf inválido");
            }
            return users.FirstOrDefault();
        }

        public string GerarToken(string nome, string email, string cpf)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, nome),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.NameIdentifier, cpf),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuracao.JwtSecretKey));
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddMinutes(10);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuracao.JwtIssuer,
                audience: _configuracao.JwtAudience,
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);


            return tokenString;
        }
    }
}
