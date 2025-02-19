using GerenciadorDeClinica.Core.Entities;

namespace GerenciadorDeClinica.Core.Repositories
{
    public interface IServicoRepository
    {
        Task<List<Servico>> GetAll();
        Task<Servico?> GetById(int id);
        Task<int> Add(Servico servico);
        Task<bool> Exist(int id);
        Task Update(Servico servico);
        Task Remove(Servico servico);

    }
}
