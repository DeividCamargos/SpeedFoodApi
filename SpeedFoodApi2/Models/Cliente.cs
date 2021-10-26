using System.ComponentModel.DataAnnotations;

namespace SpeedFoodApi2.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [StringLength(80, MinimumLength = 3, ErrorMessage = "Quantidade de caracteres não atende ao requerido")]
        public string Nome { get; set; }

        [StringLength(11, MinimumLength = 9, ErrorMessage = "Insira um número de telefone válido")]
        public string Telefone { get; set; }

        [MinLength(1, ErrorMessage = "Campo obrigatório")]
        public string Rua { get; set; }

        [MinLength(1, ErrorMessage = "Campo obrigatório")]
        public string Bairro { get; set; }


        [StringLength(11, ErrorMessage = "Número de referência do endereço é muito extenso")]
        public string Numero { get; set; }

        public string Complemento { get; set; } 
    }
}
