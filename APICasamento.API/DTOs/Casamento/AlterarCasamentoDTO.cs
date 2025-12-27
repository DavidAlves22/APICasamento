using System.ComponentModel.DataAnnotations;

namespace APICasamento.API.DTOs.Casamento
{
    public class AlterarCasamentoDTO
    {
        [Required(ErrorMessage = "Id do casamento é obrigatório")]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        public string NomeNoivo { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        public string NomeNoiva { get; set; }

        public DateTime DataCasamento { get; set; }

        [MinLength(3)]
        [MaxLength(80)]
        public string LocalCerimonia { get; set; }

        [MinLength(3)]
        [MaxLength(80)]
        public string LocalCelebracao { get; set; }
    }
}
