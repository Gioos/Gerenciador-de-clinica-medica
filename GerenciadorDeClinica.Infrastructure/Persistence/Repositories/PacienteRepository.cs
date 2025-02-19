using GerenciadorDeClinica.Core.Entities;
using GerenciadorDeClinica.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeClinica.Infrastructure.Persistence.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly GerenciadorDeClinicaDbContext _context;

        public PacienteRepository(GerenciadorDeClinicaDbContext context)
        {
            _context = context;
        }

        
        public async Task<int> Add(Paciente paciente)
        {
            
            await _context.Pacientes.AddAsync(paciente);

            _context.SaveChanges();

            return paciente.Id;
        }

        public async Task<bool> Exist(int id)
        {
           return await _context.Pacientes
                .AnyAsync(p => p.Id == id);
            
        }

        public Task<List<Paciente>> GetAll()
        {
            var pacientes = _context.Pacientes
                .Include( p => p.Atendimentos)
                .Where(p => !p.IsDeleted)
                .ToListAsync();

            return pacientes;

        }

        public async Task<Paciente?> GetByCpf(string cpf)
        {
            return await _context.Pacientes
                .SingleOrDefaultAsync(p => p.CPF == cpf);
        }

        public async Task<Paciente?> GetById(int id)
        {
            return await _context.Pacientes
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public Task Remove(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);

            await _context.SaveChangesAsync();
        }
    }
}
