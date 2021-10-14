using System;
using System.ComponentModel.DataAnnotations;
using SpeedFoodApi2.Models.Enums;

namespace SpeedFoodApi2.Models
{
    public class Candidato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} deve conter 11 caracteres")]
        public string CPF { get; set; }
        public string Email { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} deve conter 11 caracteres")]
        public string Telefone { get; set; }     
        public string Cidade { get; set; }
        public string Sexo { get; set; }
        public string Disponibilidade { get; set; } 
    }
}
