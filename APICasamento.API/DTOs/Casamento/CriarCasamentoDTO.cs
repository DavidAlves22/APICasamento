using System.ComponentModel.DataAnnotations;

namespace APICasamento.API.DTOs.Casamento
{
    public class CriarCasamentoDTO
    {
        [Required(ErrorMessage = "Nome do noivo é obrigatório")]
        [MinLength(3)]
        [MaxLength(30)]
        public string NomeNoivo { get; set; }

        [Required(ErrorMessage = "Nome da noiva é obrigatório")]
        [MinLength(3)]
        [MaxLength(30)]
        public string NomeNoiva { get; set; }


        public DateTime DataCasamento { get; set; }

        [Required(ErrorMessage = "Local da cerimônia é obrigatório")]
        [MinLength(3)]
        [MaxLength(80)]
        public string LocalCerimonia { get; set; }

        [Required(ErrorMessage = "Local da celebração é obrigatório")]
        [MinLength(3)]
        [MaxLength(80)]
        public string LocalCelebracao { get; set; }
    }
}
