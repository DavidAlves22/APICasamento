namespace APICasamento.Domain.Entities;

public class Casamento
{
    public int Id { get; private set; }
    public string NomeNoivo { get; private set; }
    public string NomeNoiva { get; private set; }
    public DateTime DataCasamento { get; private set; }
    public string LocalCerimonia { get; private set; }
    public string LocalCelebracao { get; private set; }

    public Casamento(int id, string nomeNoivo, string nomeNoiva, DateTime dataCasamento, string localCerimonia, string localCelebracao)
    {
        Id = id;
        SetNomesNoivos(nomeNoivo, nomeNoiva);
        SetDataCasamento(dataCasamento);
        SetLocais(localCerimonia, localCelebracao);
    }

    public void SetId(int id)
    {
        if(id <= 0)
            throw new ArgumentException("O ID deve ser um número positivo.", nameof(id));

        Id = id;
    }

    public void SetNomesNoivos(string nomeNoivo, string nomeNoiva)
    {
        if(string.IsNullOrWhiteSpace(nomeNoivo))
            throw new ArgumentException("O nome do noivo não pode ser vazio.", nameof(nomeNoivo));

        if(string.IsNullOrWhiteSpace(nomeNoiva))
            throw new ArgumentException("O nome da noiva não pode ser vazio.", nameof(nomeNoiva));

        NomeNoivo = nomeNoivo;
        NomeNoiva = nomeNoiva;
    }

    public void SetDataCasamento(DateTime dataCasamento)
    {
        if(dataCasamento < DateTime.Now)
            throw new ArgumentException("A data do casamento não pode ser no passado.", nameof(dataCasamento));
        DataCasamento = dataCasamento;
    }

    public void SetLocais(string localCerimonia, string localCelebracao)
    {
        if(string.IsNullOrWhiteSpace(localCerimonia))
            throw new ArgumentException("O local da cerimônia não pode ser vazio.", nameof(localCerimonia));

        if(string.IsNullOrWhiteSpace(localCelebracao))
            throw new ArgumentException("O local da celebração não pode ser vazio.", nameof(localCelebracao));

        LocalCerimonia = localCerimonia;
        LocalCelebracao = localCelebracao;
    }
}
