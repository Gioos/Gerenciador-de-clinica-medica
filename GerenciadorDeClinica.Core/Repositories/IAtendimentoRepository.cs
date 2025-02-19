using GerenciadorDeClinica.Core.Entities;

namespace GerenciadorDeClinica.Core.Repositories
{
    public interface IAtendimentoRepository
    {
        Task<List<Atendimento>> GetAll();
        Task<Atendimento?> GetById(int id);
        Task<int> Add(Atendimento atendimento);
        Task<bool> Exist(int id);
        Task Update(Atendimento atendimento);
        Task Remove(Atendimento atendimento);
    }
}
