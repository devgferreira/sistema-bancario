using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SistemaBancario.Infrastructure.Data.Context
{
    public class DbContext : IDisposable
    {
        public IDbConnection Connection { get; set; }
        public DbContext(IConfiguration configuration)
        {
            var connStr = Environment.GetEnvironmentVariable("DatabaseConnection")
                  ?? configuration.GetConnectionString("DefaultConnection");

            Connection = new NpgsqlConnection(connStr);
            Connection.Open();
        }
        public void Dispose() => Connection?.Dispose();
    }
}
