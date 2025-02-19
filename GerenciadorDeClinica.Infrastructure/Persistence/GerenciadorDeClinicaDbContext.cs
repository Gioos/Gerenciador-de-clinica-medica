using GerenciadorDeClinica.Core.Entities;
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
            builder
                .Entity<Atendimento>(a =>
                {
                    a.HasKey(a => a.Id); // chave primária

                    a.HasOne(a => a.Paciente) // Um atendimento tem um paciente
                    .WithMany(p => p.Atendimentos) // Um paciente pode ter muitos atendimentos
                    .HasForeignKey(a => a.IdPaciente) // Chave estrangeira
                    .OnDelete(DeleteBehavior.Restrict); // Comportamento ao deletar

                });
                
            builder
                .Entity<Atendimento>()
                .HasOne(a => a.Medico)
                .WithMany(m => m.Atendimentos)
                .HasForeignKey(a => a.IdMedico)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Atendimento>()
                .HasOne(a => a.Servico)
                .WithMany(s => s.Atendimentos)
                .HasForeignKey(a => a.IdServico)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(builder);
        }
    }
    
}
