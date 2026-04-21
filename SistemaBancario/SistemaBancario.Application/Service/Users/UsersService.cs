using SistemaBancario.Application.DTO.Token;
using SistemaBancario.Application.DTO.Users;
using SistemaBancario.Application.Interfaces.Authenticate;
using SistemaBancario.Application.Interfaces.Users;
using SistemaBancario.Domain.Entidades.Users;
using SistemaBancario.Domain.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Application.Service.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IAuthenticateService _authenticateService;

        public UsersService(IUsersRepository usersRepository, IAuthenticateService authenticateService)
        {
            _usersRepository = usersRepository;
            _authenticateService = authenticateService;
        }

        public async Task<TokenResponse> Login(UsersLoginRequest request)
        {

           var user = await _authenticateService.AutenticarAsync(request.Cpf, request.Senha);
           var token =  _authenticateService.GerarToken(user.Nome, user.Email.Valor, user.Cpf.Valor);

           return new TokenResponse { Token = token };
        }

        public async Task<TokenResponse> Registro(UsersRegistroRequest request)
        {


            var user = new UsersInfo();
            user.Create(request.Nome, request.Cpf, request.Email, request.Senha, request.ConfirmarSenha);

            await _usersRepository.CriarUsuario(user);
            var token = _authenticateService.GerarToken(user.Nome, user.Email.Valor, user.Cpf.Valor);

            return new TokenResponse { Token = token };
        }
    }
}
