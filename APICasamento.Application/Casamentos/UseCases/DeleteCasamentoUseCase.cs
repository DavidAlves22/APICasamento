using APICasamento.Application.Casamentos.Interfaces;

namespace APICasamento.Application.Casamentos.UseCases;

public class DeleteCasamentoUseCase
{
    private readonly ICasamentoRepository _casamentoRepository;
    public DeleteCasamentoUseCase(ICasamentoRepository casamentoRepository)
    {
        _casamentoRepository = casamentoRepository;
    }
    public async Task ExecutarAsync(int id) 
    {
        var retorno = await _casamentoRepository.GetCasamentoById(id);
        if (retorno == null)
        {
            throw new Exception("Casamento não encontrado.");
        }
        
        await _casamentoRepository.DeleteCasamento(id);
    }
}
