using System.Data;

namespace APICasamento.Domain.Entities;
public class Usuario
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Role { get; private set; }
    public byte[] PasswordHash { get; private set; }
    public byte[] PasswordSalt { get; private set; }

    public Usuario(int id, string nome, string email, string role, byte[] hash, byte[] salt)
    {
        Id = id;
        SetNome(nome);
        SetEmail(email);
        SetRole(role);
        SetPassword(hash, salt);
    }

    public void SetId(int id)
    {
        if (id <= 0)
            throw new ArgumentException("O ID deve ser um número positivo.", nameof(id));
        Id = id;
    }

    public void SetRole(string role)
    {
        if (string.IsNullOrWhiteSpace(role))
            throw new ArgumentException("A role não pode ser vazia.", nameof(role));
        Role = role;
    }

    public void SetNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome não pode ser vazio.", nameof(nome));
        Nome = nome;
    }

    public void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("O email não pode ser vazio.", nameof(email));
        Email = email;
    }

    public void SetPassword(byte[] hash, byte[] salt)
    {
        if (hash == null || hash.Length == 0)
            throw new ArgumentException("O hash da senha não pode ser nulo ou vazio.", nameof(hash));
        if (salt == null || salt.Length == 0)
            throw new ArgumentException("O salt da senha não pode ser nulo ou vazio.", nameof(salt));
        PasswordHash = hash;
        PasswordSalt = salt;
    }    
}
