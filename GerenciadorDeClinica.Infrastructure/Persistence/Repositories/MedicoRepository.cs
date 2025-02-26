using GerenciadorDeClinica.Core.Entities;
using GerenciadorDeClinica.Core.Repositories;
using Microsoft.EntityFrameworkCore;


namespace GerenciadorDeClinica.Infrastructure.Persistence.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly GerenciadorDeClinicaDbContext _context;

        public MedicoRepository(GerenciadorDeClinicaDbContext context)
        {
            _context = context;
        }


        public async Task<int> Add(Medico medico)
        {
            await _context.Medicos.AddAsync(medico);

            _context.SaveChanges();

            return medico.Id;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Existe(int id)
        {
            return await _context.Medicos
                .AnyAsync(m => m.Id == id);
        }

        public Task<List<Medico>> GetAll()
        {
            var medicos = _context.Medicos
                .AsNoTracking()
                .Include(m => m.Atendimentos)
                .Where(m => !m.IsDeleted)
                .ToListAsync();

            return medicos;
        }

        public async Task<Medico?> GetById(int id)
        {
            return await _context.Medicos
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task Update(Medico medico)
        {
            _context.Medicos.Update(medico);

            await _context.SaveChangesAsync();
        }
    }
}
