using GerenciadorDeClinica.Core.Entities;

namespace GerenciadorDeClinica.Core.Repositories
{
    public interface IUsuarioRepository
    {
        Task<int> CriarUsuarioAsync(Usuario usuario);
        //Task RecuperarSenha(Usuario usuario);
        Task<Usuario?> GetByEmailAndPasswordAsync(string email, string passwordHash);
        Task<Usuario> GetByEmailAsync(string email);
    }
}
