namespace APICasamento.Application.Autenticacao.Interfaces;

public interface ITokenService
{
    string GenerateToken(string nome, string email, string role);
}
