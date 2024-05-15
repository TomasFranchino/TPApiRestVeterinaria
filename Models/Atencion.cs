using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppVeterinaria.Models
{
    public class Atencion
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AnimalId { get; set; } // Foreign Key
        public Animal Animal { get; set; }
        [Required]
        public string Motivo { get; set; }
        public string Tratamiento { get; set; }
        public DateTime Fecha { get; set; }
        public string? Medicamentos { get; set; }
        public Atencion()
        {
          
        }
    }
}
