using SistemaBancario.Domain.Entidades.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Domain.Interfaces.Users
{
    public interface IUsersRepository
    {
        Task CriarUsuario(UsersInfo usersInfo);
        Task<List<UsersInfo>> BuscarUsuario(int id, string email, string cpf);
        Task AtualizarUsuario(int id, UsersInfo usersInfo);
        Task DeletarUsuario(int id);
    }
}
