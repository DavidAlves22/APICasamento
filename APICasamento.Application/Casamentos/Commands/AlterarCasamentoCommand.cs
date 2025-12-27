namespace APICasamento.Application.Casamentos.Commands;

public record AlterarCasamentoCommand(
    int Id,
    string NomeNoivo,
    string NomeNoiva,
    DateTime DataCasamento,
    string LocalCerimonia,
    string LocalCelebracao
);
