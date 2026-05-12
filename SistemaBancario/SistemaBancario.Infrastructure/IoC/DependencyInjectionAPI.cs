using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SistemaBancario.Application.Interfaces.Authenticate;
using SistemaBancario.Application.Interfaces.Conta;
using SistemaBancario.Application.Interfaces.Users;
using SistemaBancario.Application.Service.Authenticate;
using SistemaBancario.Application.Service.Conta;
using SistemaBancario.Application.Service.Users;
using SistemaBancario.Application.Settings;
using SistemaBancario.Domain.Interfaces.Conta;
using SistemaBancario.Domain.Interfaces.Users;
using SistemaBancario.Infrastructure.Data.Context;
using SistemaBancario.Infrastructure.Data.Repository.Conta;
using SistemaBancario.Infrastructure.Data.Repository.Users;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SistemaBancario.Infrastructure.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
            IConfiguration configuration)
        {

            var appSettings = new ConfiguracoesAplicacao
            {
                DatabaseConnection = Environment.GetEnvironmentVariable("DATABASE_CONNECTION")!,
                JwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE")!,
                JwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER")!,
                JwtSecretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY")!,

            };





            services.AddScoped<DbContext>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddSingleton<IConfiguracoesAplicacao>(appSettings);
            services.AddScoped<IContaService, ContaService>();
            services.AddScoped<IContaRepository, ContaRepository>();

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = appSettings.JwtIssuer,
                        ValidAudience = appSettings.JwtAudience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JwtSecretKey)),

                        ClockSkew = TimeSpan.Zero,

                        RoleClaimType = System.Security.Claims.ClaimTypes.Role,
                        NameClaimType = System.Security.Claims.ClaimTypes.Name
                    };
                });


            return services;
        }
    }
}
