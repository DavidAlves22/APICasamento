using APICasamento.Application.Autenticacao.Interfaces;
using System.Security.Cryptography;

namespace APICasamento.Infrastructure.Autenticacao;

public class PasswordHasher : IPasswordHasher
{
    private const int SaltSize = 16;
    private const int KeySize = 32;
    private const int Iterations = 100_000;

    public void CreateHash(string password, out byte[] hash, out byte[] salt)
    {
        using var pbkdf2 = new Rfc2898DeriveBytes(
            password,
            SaltSize,
            Iterations,
            HashAlgorithmName.SHA256);

        salt = pbkdf2.Salt;
        hash = pbkdf2.GetBytes(KeySize);
    }

    public bool Verify(string password, byte[] hash, byte[] salt)
    {
        using var pbkdf2 = new Rfc2898DeriveBytes(
            password,
            salt,
            Iterations,
            HashAlgorithmName.SHA256);

        var computed = pbkdf2.GetBytes(KeySize);

        return CryptographicOperations.FixedTimeEquals(computed, hash);
    }
}
