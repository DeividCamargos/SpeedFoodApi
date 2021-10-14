using System.ComponentModel.DataAnnotations;

namespace SpeedFoodApi2.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} deve conter 11 caracteres")]
        public string Telefone { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; } 
    }
}
