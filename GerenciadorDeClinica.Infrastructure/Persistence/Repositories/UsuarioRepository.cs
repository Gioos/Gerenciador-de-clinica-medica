using GerenciadorDeClinica.Core.Entities;
using GerenciadorDeClinica.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeClinica.Infrastructure.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly GerenciadorDeClinicaDbContext _context;

        public UsuarioRepository(GerenciadorDeClinicaDbContext context)
        {
            _context = context;
        }

        public async Task<int> CriarUsuarioAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario.Id;
        }

        public async Task AtualizarUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);

            await _context.SaveChangesAsync();

        }
        public async Task<Usuario?> GetByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _context.Usuarios
                .SingleOrDefaultAsync(u => u.Email == email && u.PasswordHash == passwordHash);


        }
        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.Email == email);


        }
    }
}
