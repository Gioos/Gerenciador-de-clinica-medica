using Microsoft.Extensions.DependencyInjection;
using GerenciadorDeClinica.Infrastructure.Repositories;
using GerenciadorDeClinica.Core.Repositories;
using Microsoft.Extensions.Configuration;
using GerenciadorDeClinica.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using GerenciadorDeClinica.Infrastructure.Persistence.Repositories;

namespace GerenciadorDeClinica.Infrastructure
{
    public static class InfrastructureModule
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddRepositories()
                .AddData(configuration);

            return services;
        }
        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAtendimentoRepository, AtendimentoRepository>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IServicoRepository, ServicoRepository>();

            return services;
        }

        private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("GerenciadorDeClinicaCs");

            services.AddDbContext<GerenciadorDeClinicaDbContext>(o=> o.UseSqlServer(connectionString));

            return services;
        }
    }
}
