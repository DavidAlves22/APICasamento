using APICasamento.Domain.Entities;

namespace APICasamento.Application.Autenticacao.Interfaces;

public interface IUsuarioRepository
{
    Task AdicionarAsync(Usuario usuario);
    Task<Usuario> GetByEmailAsync(string email);
}
