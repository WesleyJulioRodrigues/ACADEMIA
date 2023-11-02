using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academia.Models;

[Table("Professor")]
public class Professor
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

    [StringLength(300)]
    public string Facebook { get; set; }

    [StringLength(300)]
    public string Instagram { get; set; }

    [StringLength(300)]
    public string Foto { get; set; }
}
