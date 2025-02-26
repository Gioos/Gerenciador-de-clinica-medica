using GerenciadorDeClinica.Core.Entities;
using GerenciadorDeClinica.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeClinica.Infrastructure.Persistence.Repositories
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly GerenciadorDeClinicaDbContext _context;

        public ServicoRepository(GerenciadorDeClinicaDbContext context)
        {
            _context = context;
        }


        public async Task<int> Add(Servico servico)
        {
            await  _context.Servicos.AddAsync(servico);

            _context.SaveChanges();

            return servico.Id;
        }

        public Task<bool> Exist(int id)
        {
            return _context.Servicos.AnyAsync(s => s.Id == id);
        }

        public Task<List<Servico>> GetAll()
        {
            var servicos = _context.Servicos
                .AsNoTracking()
                .Include(a => a.Atendimentos)
                .Where(servico => !servico.IsDeleted)
                .ToListAsync();

            return servicos;
        }

        public async Task<Servico?> GetById(int id)
        {
            return await _context.Servicos
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public Task Remove(Servico servico)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Servico servico)
        {
            _context.Servicos.Update(servico);

            await _context.SaveChangesAsync();
        }
    }
}
