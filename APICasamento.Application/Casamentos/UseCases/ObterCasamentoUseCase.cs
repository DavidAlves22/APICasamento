using APICasamento.Application.Casamentos.Interfaces;
using APICasamento.Application.Casamentos.Queries;
using APICasamento.Domain.Entities;

namespace APICasamento.Application.Casamentos.UseCases;

public class ObterCasamentoUseCase
{
    private readonly ICasamentoRepository _casamentoRepository;

    public ObterCasamentoUseCase(ICasamentoRepository casamentoRepository)
    {
        _casamentoRepository = casamentoRepository;
    }

    public async Task<List<Casamento>> ExecutarAsync()
    {
        var casamentos = await _casamentoRepository.GetCasamentos();
        return casamentos;
    }
}
