using System.ComponentModel.DataAnnotations;

namespace APICasamento.API.DTOs.Autenticacao
{
    public class RegistrarDTO
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
