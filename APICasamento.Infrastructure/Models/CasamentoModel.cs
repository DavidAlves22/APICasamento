namespace APICasamento.Infrastructure.Models;

public class CasamentoModel
{
    public int Id { get; set; }
    public string NomeNoivo { get; set; }
    public string NomeNoiva { get; set; }
    public DateTime DataCasamento { get; set; }
    public string LocalCerimonia { get; set; }
    public string LocalCelebracao { get; set; }
}
