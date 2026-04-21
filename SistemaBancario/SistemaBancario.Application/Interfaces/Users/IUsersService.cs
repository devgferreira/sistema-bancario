using SistemaBancario.Application.DTO.Token;
using SistemaBancario.Application.DTO.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Application.Interfaces.Users
{
    public interface IUsersService
    {
        Task<TokenResponse> Login(UsersLoginRequest request);
        Task<TokenResponse> Registro(UsersRegistroRequest request);
            
    }
}
