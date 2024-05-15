using WebAppVeterinaria.Models;

namespace WebAppVeterinaria.DTO
{
    public class DTODueño
    {

        public class GetDTODueño
        {
            public int Dni { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Telefono { get; set; }
        }

        public class PutDTODueño
        {
            public int Dni { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Telefono { get; set; }
        }

        public class PostDTODueño
        {
            public int Dni { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Telefono { get; set; }
        }

    }
}
