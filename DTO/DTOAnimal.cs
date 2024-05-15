namespace WebAppVeterinaria.DTO
{
    public class DTOAnimal
    {
       

        public class PostDTOAnimal
        {
            public string Nombre { get; set; }
            public string Especie { get; set; }
            public string Raza { get; set; }
            public int Edad { get; set; }
            public string Sexo { get; set; }
        }

        public class PutDTOAnimal
        {
            public string Nombre { get; set; }
            public string Especie { get; set; }
            public string Raza { get; set; }
            public int Edad { get; set; }
            public string Sexo { get; set; }
            public int? IdDueño { get; set; }
        }

        public class AsignarDueñoDTOAnimal
        {
            public int Id { get; set; }
            public int? IdDueño { get; set; }
        }
    }
}