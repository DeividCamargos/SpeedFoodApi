

using System.ComponentModel.DataAnnotations;

namespace SpeedFoodApi2.Models
{
    public class Avaliacao
    {
        public int Id { get; set; }

        [StringLength(80, MinimumLength = 3, ErrorMessage = "Quantidade de caracteres não atende ao requerido")]
        public string Nome { get; set; }

        [StringLength(500, MinimumLength = 1, ErrorMessage = "Quantidade de caracteres não atende ao requerido")]
        public string Descricao { get; set; } 
    }
}
