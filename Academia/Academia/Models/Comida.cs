using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academia.Models;

[Table("ComidaRecomendada")]
public class Comida
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(60)]
    public string Nome { get; set; }

    [Required]
    [StringLength(1000)]
    public string Descricao { get; set; }

    [Required]
    [StringLength(60)]
    public string Tipo { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "As calorias devem ser um número positivo.")]
    public int Calorias { get; set; }

    [StringLength(300)]
    public string Foto { get; set; }
}


