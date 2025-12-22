using APICasamento.Application.Autenticacao.Commands;
using APICasamento.Application.Autenticacao.Interfaces;

namespace APICasamento.Application.Autenticacao.UseCases;

public class LoginUseCase
{
    private readonly IUsuarioRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenService _tokenService;

    public LoginUseCase(
        IUsuarioRepository userRepository,
        IPasswordHasher passwordHasher,
        ITokenService tokenService)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
    }

    public async Task<string> ExecutarAsync(LoginCommand command)
    {
        var usuario = await _userRepository.GetByEmailAsync(command.Email)
            ?? throw new Exception("Usuário não encontrado");

        var valid = _passwordHasher.Verify(
            command.Password,
            usuario.PasswordHash,
            usuario.PasswordSalt);

        if (!valid)
            throw new Exception("Senha inválida");

        return _tokenService.GenerateToken(usuario.Nome, usuario.Email, usuario.Role);
    }
}
