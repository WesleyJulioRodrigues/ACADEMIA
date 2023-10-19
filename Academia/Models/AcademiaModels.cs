using System.ComponentModel.DataAnnotations;
using Academia.Data;

namespace Academia.Models
{
    public class ComidaRecomendada
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "As calorias devem ser um número positivo.")]
        public int Calorias { get; set; }
    }

    public class Professor
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Especialidade { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Telefone { get; set; }
    }
}