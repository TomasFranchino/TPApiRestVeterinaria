using WebAppVeterinaria.Models;

namespace WebAppVeterinaria.DTO
{
    public class DTOAtencion
    {
        public class PostDTOAtencion
        {
            public int Id { get; set; }
            public Animal Animal { get; set; }
            public string Motivo { get; set; }
            public string Tratamiento { get; set; }
            public DateTime Fecha { get; set; }
            public string Medicamentos { get; set; }
        }

        public class GetDTOAtencion
        {
            public int Id { get; set; }
            public Animal Animal { get; set; }
            public string Motivo { get; set; }
            public string Tratamiento { get; set; }
            public DateTime Fecha { get; set; }
            public string Medicamentos { get; set; }
        }

        public class PutDTOAtencion
        {
            public int Id { get; set; }
            public Animal Animal { get; set; }
            public string Motivo { get; set; }
            public string Tratamiento { get; set; }
            public DateTime Fecha { get; set; }
            public string Medicamentos { get; set; }

        }
        

    }
}
