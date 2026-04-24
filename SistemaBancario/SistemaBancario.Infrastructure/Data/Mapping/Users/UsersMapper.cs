using SistemaBancario.Domain.Entidades.Users;
using SistemaBancario.Infrastructure.Data.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Infrastructure.Data.Mapping.Users
{
    public static class UsersMapper
    {
        public static UsersEntity MapToUsersEntity(this UsersInfo request)
        {
            return new UsersEntity
            {
                Nome = request.Nome,
                Cpf = request.Cpf.Valor,
                Email = request.Email.Valor,
                Senha = request.Senha.Hash
            };
        }

        public static UsersInfo MapToUsersInfo(this UsersEntity request)
        {

            return  new UsersInfo().CriarSemConfiirmarSenha(request.Id, request.Nome, request.Cpf, request.Email, request.Senha);
        }
    }
}
