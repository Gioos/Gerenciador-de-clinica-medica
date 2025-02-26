using GerenciadorDeClinica.Core.Entities;
using GerenciadorDeClinica.Infrastructure.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeClinica.Infrastructure.Persistence
{
    public class GerenciadorDeClinicaDbContext : DbContext
    {
        public GerenciadorDeClinicaDbContext(DbContextOptions<GerenciadorDeClinicaDbContext> options) : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<Servico> Servicos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AtendimentoMap());
        }
    }
    
}
