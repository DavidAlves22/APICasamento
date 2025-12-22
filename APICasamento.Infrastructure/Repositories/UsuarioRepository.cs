using APICasamento.Application.Autenticacao.Interfaces;
using APICasamento.Domain.Entities;
using APICasamento.Infrastructure.Models;
using APICasamento.Infrastructure.Mappers;

namespace APICasamento.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private static readonly List<UsuarioModel> _usuarios = new List<UsuarioModel>();

    public UsuarioRepository()
    {

        var usuario = new UsuarioModel
        {
            Id = 1,
            Nome = "david",
            Email = "david@hotmail.com",
            Role = "Administrador",
            PasswordHash = new byte[]
            {
                32,204,42,65,111,106,251,70,
                56,151,80,172,238,170,222,175,
                231,103,133,252,11,99,209,24,
                92,64,239,193,6,180,237,62
            },
            PasswordSalt = new byte[]
            {
                63,133,195,126,17,90,133,100,
                245,210,183,42,157,175,102,60
            }
        };

        _usuarios.Add(usuario);
    }

    public Task AdicionarAsync(Usuario usuario)
    {
        var proximoId = _usuarios.Any() ? _usuarios.Max(p => p.Id) + 1 : 1;
        usuario.SetId(proximoId);

        _usuarios.Add(usuario.ToModel());
        return Task.CompletedTask;
    }

    public Task<Usuario> GetByEmailAsync(string email)
    {
        var usuario = _usuarios.FirstOrDefault(p => p.Email == email);

        return usuario == null ? Task.FromResult<Usuario>(null) : Task.FromResult(usuario.ToDomain());
    }

}
