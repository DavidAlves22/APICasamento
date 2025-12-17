using APICasamento.Domain.Entities;

namespace APICasamento.Application.Repositories;

public interface ICasamentoRepository
{
    Task<List<Casamento>> GetCasamentos();
    Task<Casamento> GetCasamentoById(int id);
    Task CreateCasamento(Casamento casamento);
    Task UpdateCasamento(Casamento casamento);
    Task DeleteCasamento(int id);
}
