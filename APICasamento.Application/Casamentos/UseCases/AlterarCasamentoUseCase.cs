using APICasamento.Application.Casamentos.Commands;
using APICasamento.Application.Casamentos.Interfaces;

namespace APICasamento.Application.Casamentos.UseCases;

public class AlterarCasamentoUseCase
{
    private readonly ICasamentoRepository _casamentoRepository;

    public AlterarCasamentoUseCase(ICasamentoRepository casamentoRepository)
    {
        _casamentoRepository = casamentoRepository;
    }

    public async Task ExecutarAsync(AlterarCasamentoCommand command) 
    {
        var casamentoAlterar = await _casamentoRepository.GetCasamentoById(command.Id);
        if (casamentoAlterar == null)
        {
            throw new Exception("Casamento não encontrado.");
        }

        casamentoAlterar.AlterarCasamento(
            command.Id,
            command.NomeNoivo,
            command.NomeNoiva,
            command.DataCasamento,
            command.LocalCerimonia,
            command.LocalCelebracao
        );

        await _casamentoRepository.UpdateCasamento(casamentoAlterar);
    }
}
