
using System.ComponentModel.DataAnnotations;
using Academia.Models;

namespace Professor.Models
{
    
   public class Professor
    {
        [Key]

        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }    
        
    }
}