using Microsoft.Extensions.DependencyInjection;
using GerenciadorDeClinica.Infrastructure.Repositories;
using GerenciadorDeClinica.Core.Repositories;
using Microsoft.Extensions.Configuration;
using GerenciadorDeClinica.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using GerenciadorDeClinica.Infrastructure.Persistence.Repositories;
using GerenciadorDeClinica.Infrastructure.Notifications;
using GerenciadorDeClinica.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SendGrid.Extensions.DependencyInjection;
using System.Text;

namespace GerenciadorDeClinica.Infrastructure
{
    public static class InfrastructureModule
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddRepositories()
                .AddData(configuration)
                .AddAuth(configuration)
                .AddEmailService(configuration);
            

            return services;
        }
        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAtendimentoRepository, AtendimentoRepository>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IServicoRepository, ServicoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }

        private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("GerenciadorDeClinicaCs");

            services.AddDbContext<GerenciadorDeClinicaDbContext>(o=> o.UseSqlServer(connectionString));

            return services;
        }
        private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthService, AuthService>();

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))

                    };
                });
            return services;
        }
        private static IServiceCollection AddEmailService(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddSendGrid(o =>
                {
                    o.ApiKey = configuration.GetValue<string>("SendGrid:ApiKey");
                });

            services.AddScoped<IEmailService, EmailService>();

            return services;
        }
    }
}
