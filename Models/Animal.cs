using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppVeterinaria.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Especie { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Raza { get; set; }
        [Required]
        public int Edad { get; set; }
        [Required]
        public string Sexo { get; set; }
        public int? DueñoId { get; set; } // Clave foránea
        public Dueño Dueño { get; set; } // Propiedad de navegación

        public Animal()
        {
           
        }
        

    }
}
