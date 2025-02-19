using GerenciadorDeClinica.Core.Entities;

namespace GerenciadorDeClinica.Core.Repositories
{
    public interface IPacienteRepository
    {
        Task<List<Paciente>> GetAll();
        Task<Paciente?> GetById(int id);
        Task<Paciente?> GetByCpf(string cpf);
        Task<int> Add(Paciente  paciente);
        Task<bool> Exist(int id);
        Task Update(Paciente paciente);
        Task Remove(Paciente paciente);
    }
}
