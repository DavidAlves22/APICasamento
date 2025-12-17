using APICasamento.Application.DTOs;
using APICasamento.Application.Repositories;
using APICasamento.Domain.Entities;
using System;
namespace APICasamento.Application.UseCases.CasamentoUseCases
{
    public class CriarCasamentoUseCase
    {
        private readonly ICasamentoRepository _casamentoRepository;

        public CriarCasamentoUseCase(ICasamentoRepository casamentoRepository)
        {
            _casamentoRepository = casamentoRepository;
        }

        public async Task<int> ExecutarAsync(CriarCasamentoDTO casamentoDTO)
        {
            var casamento = new Casamento(
                0,
                casamentoDTO.NomeNoivo,
                casamentoDTO.NomeNoiva,
                casamentoDTO.DataCasamento,
                casamentoDTO.LocalCerimonia,
                casamentoDTO.LocalCelebracao
            );

            await _casamentoRepository.CreateCasamento(casamento);

            return casamento.Id;
        }
    }
}
