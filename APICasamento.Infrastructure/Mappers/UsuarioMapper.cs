using APICasamento.Domain.Entities;
using APICasamento.Infrastructure.Models;

namespace APICasamento.Infrastructure.Mappers
{
    public static class UsuarioMapper
    {
        public static Usuario ToDomain(this UsuarioModel usuario)
        {
            return new Usuario(usuario.Id, usuario.Nome, usuario.Email, usuario.Role, usuario.PasswordHash, usuario.PasswordSalt);
        }

        public static UsuarioModel ToModel(this Usuario usuario)
        {
            return new UsuarioModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Role = usuario.Role,
                PasswordHash = usuario.PasswordHash,
                PasswordSalt = usuario.PasswordSalt
            };
        }
    }
}
