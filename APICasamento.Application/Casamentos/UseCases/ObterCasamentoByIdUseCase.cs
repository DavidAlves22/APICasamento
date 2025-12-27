using APICasamento.Application.Casamentos.Interfaces;
using APICasamento.Application.Casamentos.Queries;
using APICasamento.Domain.Entities;

namespace APICasamento.Application.Casamentos.UseCases;

public class ObterCasamentoByIdUseCase
{
    private readonly ICasamentoRepository _casamentoRepository;

    public ObterCasamentoByIdUseCase(ICasamentoRepository casamentoRepository)
    {
        _casamentoRepository = casamentoRepository;
    }

    public async Task<Casamento> ExecutarAsync(ObterCasamentoByIdQuery query)
    {
        var casamento = await _casamentoRepository.GetCasamentoById(query.Id);
        return casamento;
    }
}
