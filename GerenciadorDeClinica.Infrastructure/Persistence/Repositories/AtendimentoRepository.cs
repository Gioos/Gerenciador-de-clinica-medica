using GerenciadorDeClinica.Core.Entities;
using GerenciadorDeClinica.Core.Repositories;
using GerenciadorDeClinica.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeClinica.Infrastructure.Repositories
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        private readonly GerenciadorDeClinicaDbContext _context;
        public AtendimentoRepository(GerenciadorDeClinicaDbContext context)
        {
            _context = context;
        }


        public async Task<int> Add(Atendimento atendimento)
        {
            await _context.Atendimentos.AddAsync(atendimento);
            _context.SaveChanges();

            return atendimento.Id;
        }

        public async Task<bool> Exist(int id)
        {
            return await _context.Atendimentos.AnyAsync(a => a.Id == id);
        }

        public Task<List<Atendimento>> GetAll()
        {
            var atendimentos = _context.Atendimentos
                .AsNoTracking()
                .Include(p => p.Paciente)
                .Include(m => m.Medico)
                .Where(atendimentos => !atendimentos.IsDeleted)
                .ToListAsync();

            return atendimentos;
        }

        public async Task<Atendimento?> GetById(int id)
        {
            return await _context.Atendimentos
                .AsNoTracking()
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public Task Remove(Atendimento atendimento)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Atendimento atendimento)
        {
            _context.Atendimentos.Update(atendimento);
            await _context.SaveChangesAsync();
        }
    }
}
