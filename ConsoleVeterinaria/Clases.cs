using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleVeterinaria
{
    public class Clases
    {
        public class Dueño
        {

            public int Id { get; set; }

            public int Dni { get; set; }

            public string Nombre { get; set; }

            public string Apellido { get; set; }
            public string Telefono { get; set; }


            public Dueño()
            {

            }
        }

        public class Animal
        {

            public int Id { get; set; }

            public string Especie { get; set; }

            public string Nombre { get; set; }
            public string Raza { get; set; }

            public int Edad { get; set; }

            public string Sexo { get; set; }
            public int? DueñoId { get; set; } 
            public Dueño Dueño { get; set; }

            public Animal()
            {

            }

        }
        public class Atencion
        {
          
            public int Id { get; set; }
          
            public int AnimalId { get; set; } 
            public Animal Animal { get; set; }
           
            public string Motivo { get; set; }
            public string Tratamiento { get; set; }
            public DateTime Fecha { get; set; }
            public string? Medicamentos { get; set; }
            public Atencion()
            {

            }

            
            
        }
        public class ResponseDto
        {
            [JsonPropertyName("data")]
            public object Data { get; set; }

            [JsonPropertyName("isSuccess")]
            public bool IsSuccess { get; set; }

            [JsonPropertyName("message")]
            public string Message { get; set; }
            public ResponseDto()
            {

            }
        }
    }
}

