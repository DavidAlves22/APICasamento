namespace APICasamento.Application.Casamentos.Commands;

public record CriarCasamentoCommand(
    string NomeNoivo,
    string NomeNoiva,
    DateTime DataCasamento,
    string LocalCerimonia,
    string LocalCelebracao
);
