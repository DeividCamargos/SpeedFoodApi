using System;
using System.ComponentModel.DataAnnotations;
using SpeedFoodApi2.Models.Enums;

namespace SpeedFoodApi2.Models
{
    public class Candidato
    {
        public int Id { get; set; }

        [StringLength(80, MinimumLength = 3, ErrorMessage = "Quantidade de caracteres não atende ao requerido")]
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} deve conter 11 caracteres")]
        public string CPF { get; set; }

        public string Email { get; set; }

        [StringLength(11, MinimumLength = 9, ErrorMessage = "Insira um número de telefone válido")]
        public string Telefone { get; set; }     

        [MinLength(1, ErrorMessage = "Campo obrigatório")]
        public string Cidade { get; set; }

        public string Sexo { get; set; }

        public string Disponibilidade { get; set; } 
    }
}
