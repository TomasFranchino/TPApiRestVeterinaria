using System.ComponentModel.DataAnnotations;

namespace WebAppVeterinaria.Models
{
    public class Dueño
    {
        [Key]
        public int Id { get; set; }
        public int Dni { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        

        public Dueño()
        {
            
        }
    }
}
