using System; 
using SpeedFoodApi2.Models.Enums;

namespace SpeedFoodApi2.Models
{
    public class Candidato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }    
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public Sexo Sexo { get; set; }
        public Disponibilidade Disponibilidade { get; set; } 
    }
}
