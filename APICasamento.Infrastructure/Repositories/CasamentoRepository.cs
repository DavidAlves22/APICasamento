using APICasamento.Application.Casamentos.Interfaces;
using APICasamento.Domain.Entities;
using APICasamento.Infrastructure.Mappers;
using APICasamento.Infrastructure.Models;

namespace APICasamento.Infrastructure.Repositories
{
    public class CasamentoRepository : ICasamentoRepository
    {
        private static readonly List<CasamentoModel> _casamentos = new List<CasamentoModel>();

        public CasamentoRepository() {

            var casamento = new CasamentoModel
            {
                Id = 1,
                NomeNoivo = "João Pedro",
                NomeNoiva = "Ana Clara",
                DataCasamento = new DateTime(2026, 10, 25),
                LocalCerimonia = "Igreja Matriz",
                LocalCelebracao = "Salão de Festas Felicidade"
            };

            _casamentos.Add(casamento);
        }

        public Task<List<Casamento>> GetCasamentos()
        {
            var listaCasamentos = _casamentos.Select(c => c.ToDomain()).ToList();
            return Task.FromResult(listaCasamentos);
        }

        public Task<Casamento> GetCasamentoById(int id)
        {
            var casamento = _casamentos.FirstOrDefault(p => p.Id == id);

            return casamento == null ? Task.FromResult<Casamento>(null) : Task.FromResult(casamento.ToDomain());
        }

        public Task CreateCasamento(Casamento casamento)
        {
            var proximoId = _casamentos.Any() ? _casamentos.Max(p => p.Id) + 1 : 1;
            casamento.SetId(proximoId);

            _casamentos.Add(casamento.ToModel());
            return Task.CompletedTask;
        }

        public Task UpdateCasamento(Casamento casamento)
        {
            var existingPedido = _casamentos.FirstOrDefault(p => p.Id == casamento.Id);
            if (existingPedido != null)
            {
                _casamentos.Remove(existingPedido);
                _casamentos.Add(casamento.ToModel());
            }
            return Task.CompletedTask;
        }

        public Task DeleteCasamento(int id)
        {
            var casamento = _casamentos.FirstOrDefault(p => p.Id == id);
            if (casamento != null)
            {
                _casamentos.Remove(casamento);
            }

            return Task.CompletedTask;
        }
    }
}
