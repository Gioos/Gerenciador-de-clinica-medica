using GerenciadorDeClinica.Core.Entities;

namespace GerenciadorDeClinica.Core.Repositories
{
    public interface IMedicoRepository
    {
        Task<List<Medico>> GetAll();
        Task<Medico?> GetById(int id);
        Task<bool> Existe(int id);
        Task<int> Add(Medico medico);
        Task Update(Medico medico); 
        Task Delete(int id);

    }
}
