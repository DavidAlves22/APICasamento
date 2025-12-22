using APICasamento.Application.Casamentos.Commands;
using APICasamento.Application.Casamentos.Interfaces;
using APICasamento.Domain.Entities;

namespace APICasamento.Application.Casamentos.UseCases;

public class CriarCasamentoUseCase
{
    private readonly ICasamentoRepository _casamentoRepository;

    public CriarCasamentoUseCase(ICasamentoRepository casamentoRepository)
    {
        _casamentoRepository = casamentoRepository;
    }

    public async Task<int> ExecutarAsync(CriarCasamentoCommand command)
    {
        var casamento = new Casamento(
            0,
            command.NomeNoivo,
            command.NomeNoiva,
            command.DataCasamento,
            command.LocalCerimonia,
            command.LocalCelebracao
        );

        await _casamentoRepository.CreateCasamento(casamento);

        return casamento.Id;
    }
}
