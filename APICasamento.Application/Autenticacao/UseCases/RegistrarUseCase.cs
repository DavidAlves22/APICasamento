using APICasamento.Application.Autenticacao.Commands;
using APICasamento.Application.Autenticacao.Interfaces;
using APICasamento.Domain.Entities;

namespace APICasamento.Application.Autenticacao.UseCases;

public class RegistrarUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegistrarUseCase(
        IUsuarioRepository usuarioRepository,
        IPasswordHasher passwordHasher)
    {
        _usuarioRepository = usuarioRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task ExecutarAsync(RegistrarCommand command)
    {
        var retornoUsuario = await _usuarioRepository.GetByEmailAsync(command.Email);
        if (retornoUsuario != null)
            throw new Exception("Usuário já existe");

        _passwordHasher.CreateHash(
            command.Password,
            out var hash,
            out var salt);

        var usuario = new Usuario(0, command.Nome, command.Email, "Administrador", hash, salt);

        await _usuarioRepository.AdicionarAsync(usuario);
    }
}
