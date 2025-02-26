using GerenciadorDeClinica.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorDeClinica.Infrastructure.Persistence.Mappings
{
    public class AtendimentoMap : IEntityTypeConfiguration<Atendimento>
    {
        public void Configure(EntityTypeBuilder<Atendimento> builder)
        {
            builder
                  .HasKey(a => a.Id); // chave primária

            builder
                  .HasOne(a => a.Paciente) // Um atendimento tem um paciente
                  .WithMany(p => p.Atendimentos) // Um paciente pode ter muitos atendimentos
                  .HasForeignKey(a => a.IdPaciente) // Chave estrangeira
                  .OnDelete(DeleteBehavior.Restrict); // Comportamento ao deletar

            builder
                .HasOne(a => a.Medico)
                .WithMany(m => m.Atendimentos)
                .HasForeignKey(a => a.IdMedico)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(a => a.Servico)
                .WithMany(s => s.Atendimentos)
                .HasForeignKey(a => a.IdServico)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
