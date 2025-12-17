using APICasamento.Domain.Entities;
using APICasamento.Infrastructure.Models;

namespace APICasamento.Infrastructure.Mappers
{
    public static class CasamentoMapper
    {
        public static Casamento ToDomain(this CasamentoModel casamento)
        {
            return new Casamento(casamento.Id, casamento.NomeNoivo, casamento.NomeNoiva, casamento.DataCasamento, casamento.LocalCerimonia, casamento.LocalCelebracao);
        }

        public static CasamentoModel ToModel(this Casamento casamento)
        {
            return new CasamentoModel
            {
                Id = casamento.Id,
                NomeNoivo = casamento.NomeNoivo,
                NomeNoiva = casamento.NomeNoiva,
                DataCasamento = casamento.DataCasamento,
                LocalCerimonia = casamento.LocalCerimonia,
                LocalCelebracao = casamento.LocalCelebracao
            };
        }
    }
}
