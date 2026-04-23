using Dapper;
using SistemaBancario.Domain.Entidades.Users;
using SistemaBancario.Domain.Interfaces.Users;
using SistemaBancario.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario.Infrastructure.Data.Repository.Users
{
    public class UsersRepository : IUsersRepository
    {
        private DbContext _context;

        public UsersRepository(DbContext context)
        {
            _context = context;
        }

        public async Task AtualizarUsuario(int id, UsersInfo usersInfo)
        {
            var sql = @"UPDATE Users SET Nome = @Nome, Cpf = @Cpf, Email = @Email WHERE Id = @Id";
            await _context.Connection.ExecuteAsync(sql, new { Nome = usersInfo.Nome, Cpf = usersInfo.Cpf, Email = usersInfo.Email, Id = id });
        }

        public async Task<List<UsersInfo>> BuscarUsuario(int? id, string? email, string? cpf)
        {
            var sql =  @"SELECT ID, CPF, NOME, EMAIL FROM Users WHERE 1 = 1 ";
            
            if (id != null)
            {
                sql += " AND Id = @Id ";
            }
            if (email != null) {
                sql += " AND Email = @Email ";
            }
            if (cpf != null)
            {
                sql += " AND Cpf = @Cpf ";
            }
            var result = await _context.Connection.QueryAsync<UsersInfo>(sql, new { Id = id, Email = email, Cpf = cpf });
            return result.ToList();
        }

        public async Task CriarUsuario(UsersInfo usersInfo)
        {
            var sql = @"INSERT INTO Users (Nome, Cpf, Email, Senha) VALUES (@Nome, @Cpf, @Email, @Senha)";

            await _context.Connection.ExecuteAsync(sql, new { Nome = usersInfo.Nome, Cpf = usersInfo.Cpf.Valor, Email = usersInfo.Email.Valor, Senha = usersInfo.Senha.Hash });
        }

        public async Task DeletarUsuario(int id)
        {
            var sql = @"DELETE FROM Users WHERE Id = @Id";

            await _context.Connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
