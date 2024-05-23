using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleVeterinaria
{

    class Program
    {
        static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7072/")
        };

        static async Task Main()
        {
            
            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Obtener todos los dueños");
                Console.WriteLine("2. Obtener dueño por ID");
                Console.WriteLine("3. Crear un nuevo dueño");
                Console.WriteLine("4. Actualizar un dueño");
                Console.WriteLine("5. Eliminar un dueño");
                Console.WriteLine("6. Obtener todos los animales");
                Console.WriteLine("7. Obtener animal por ID");
                Console.WriteLine("8. Crear un nuevo animal");
                Console.WriteLine("9. Actualizar un animal");
                Console.WriteLine("10. Eliminar un animal");
                Console.WriteLine("11. Asignar dueño a un animal");
                Console.WriteLine("12. Crear una nueva atención");
                Console.WriteLine("13. Obtener medicamento por ID de atencion");
                Console.WriteLine("14. Salir");

                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        await GetDueños();
                        break;
                    case "2":
                        Console.Write("Ingrese el ID del dueño: ");
                        int idDueño = int.Parse(Console.ReadLine());
                        await GetDueño(idDueño);
                        break;
                    case "3":
                        Console.Write("Ingrese el DNI: ");
                        int Dni = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el Nombre: ");
                        string Nombre = Console.ReadLine();
                        Console.Write("Ingrese el Apellido: ");
                        string Apellido = Console.ReadLine();
                        Console.Write("Ingrese el Teléfono: ");
                        string Telefono = Console.ReadLine();

                        await PostDueño(Dni, Nombre, Apellido, Telefono);
                        break;
                    case "4":
                        Console.Write("Ingrese el ID del dueño: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el DNI: ");
                        int actualizarDni = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el Nombre: ");
                        string actualizarNombre = Console.ReadLine();
                        Console.Write("Ingrese el Apellido: ");
                        string actualizarApellido = Console.ReadLine();
                        Console.Write("Ingrese el Teléfono: ");
                        string actualizarTelefono = Console.ReadLine();

                        await PutDueño(id, actualizarDni, actualizarNombre, actualizarApellido, actualizarTelefono);
                        break;
                    case "5":
                        Console.Write("Ingrese el ID del dueño a eliminar: ");
                        int idEliminarDueño = int.Parse(Console.ReadLine());
                        await DeleteDueño(idEliminarDueño);
                        break;
                    case "6":
                        await GetAnimales();
                        break;
                    case "7":
                        Console.Write("Ingrese el ID del animal: ");
                        int idAnimal = int.Parse(Console.ReadLine());
                        await GetAnimal(idAnimal);
                        break;
                    case "8":
                        Console.Write("Ingrese la Especie: ");
                        string Especie = Console.ReadLine();
                        Console.Write("Ingrese el Nombre: ");
                        string animalNombre = Console.ReadLine();
                        Console.Write("Ingrese la Raza: ");
                        string Raza = Console.ReadLine();
                        Console.Write("Ingrese la Edad: ");
                        int Edad = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el Sexo: ");
                        string Sexo = Console.ReadLine();

                        await PostAnimal(Especie, animalNombre, Raza, Edad, Sexo);
                        break;
                    case "9":
                        Console.Write("Ingrese el ID del animal: ");
                        int idAnimalAct = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese la Especie: ");
                        string actualizarEspecie = Console.ReadLine();
                        Console.Write("Ingrese el Nombre: ");
                        string actualizarAnimalNombre = Console.ReadLine();
                        Console.Write("Ingrese la Raza: ");
                        string actualizarRaza = Console.ReadLine();
                        Console.Write("Ingrese la Edad: ");
                        int actualizarEdad = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el Sexo: ");
                        string actualizarSexo = Console.ReadLine();

                        await PutAnimal(idAnimalAct, actualizarEspecie, actualizarAnimalNombre, actualizarRaza, actualizarEdad, actualizarSexo);
                        break;
                    case "10":
                        Console.Write("Ingrese el ID del animal a eliminar: ");
                        int idEliminarAnimal = int.Parse(Console.ReadLine());
                        await DeleteAnimal(idEliminarAnimal);
                        break;
                    case "11":
                        Console.Write("Ingrese el ID del animal: ");
                        int idanimal = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el ID del dueño: ");
                        int iddueño = int.Parse(Console.ReadLine());
                        await AsignarDueño(idanimal, iddueño);
                        break;
                    case "12":
                        Console.Write("Ingrese el ID del animal: ");
                        int AnimalId = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el motivo: ");
                        string Motivo = Console.ReadLine();
                        Console.Write("Ingrese el tratamiento: ");
                        string Tratamiento = Console.ReadLine();
                        Console.Write("Ingrese la fecha (yyyy-MM-dd): ");
                        DateTime Fecha = DateTime.Parse(Console.ReadLine());
                        Console.Write("Ingrese los medicamentos (opcional): ");
                        string Medicamentos = Console.ReadLine();

                        await PostAtencion(AnimalId, Motivo, Tratamiento, Fecha, Medicamentos);
                        break;
                    case "13":
                        Console.Write("Ingrese el ID de atencion: ");
                        int idMedicamento = int.Parse(Console.ReadLine());
                        await GetMedicamento(idMedicamento);
                        break;
                    case "14":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
                if (continuar)
                {
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                }

                          
            }

            //Metodos consola Dueños
            static async Task GetDueños()
            {
                

                string dueños = null;

                HttpResponseMessage response = await client.GetAsync("api/dueño/GetDueños");

               
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<Clases.ResponseDto>(responseContent);

                    if (apiResponse.IsSuccess == false)
                    {
                        Console.WriteLine($"{apiResponse.Message}");
                    }
                    else
                    {
                        dueños = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(dueños);
                    }
                   
           
                
            }
            static async Task GetDueño(int id)
            {
               
                string dueño = null;

                HttpResponseMessage response = await client.GetAsync($"api/dueño/GetDueño/{id}");

               
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<Clases.ResponseDto>(responseContent);

                    if (apiResponse.IsSuccess == false)
                    {
                        Console.WriteLine($"{apiResponse.Message}");
                    }
                    else
                    {
                        dueño = await response.Content.ReadAsStringAsync();
                    }
                    
               
                Console.WriteLine(dueño);
            }
            static async Task PostDueño(int Dni, string Nombre, string Apellido, string Telefono)
            {

                Clases.Dueño dueño = new Clases.Dueño();

                dueño.Dni = Dni;
                dueño.Nombre = Nombre;
                dueño.Apellido = Apellido;
                dueño.Telefono = Telefono;

                string json = JsonSerializer.Serialize(dueño);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("api/dueño/PostDueños", content);

               
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<Clases.ResponseDto>(responseContent);

                    if (apiResponse.IsSuccess == false)
                    {
                        Console.WriteLine($"{apiResponse.Message}");
                    }
                    else
                    {
                        Console.WriteLine("Dueño cargado correctamente");
                    }
                   
            
            }
            static async Task PutDueño(int id, int Dni, string Nombre, string Apellido, string Telefono)
            {
               
                Clases.Dueño dueño = new Clases.Dueño();

                dueño.Dni = Dni;
                dueño.Nombre = Nombre;
                dueño.Apellido = Apellido;
                dueño.Telefono = Telefono;

                string json = JsonSerializer.Serialize(dueño);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync($"api/dueño/PutDueño/{id}", content);
                               
                string responseContent = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<Clases.ResponseDto>(responseContent);

                if (apiResponse.IsSuccess == false)
                {
                    Console.WriteLine($"{apiResponse.Message}");
                }
                else
                {
                    Console.WriteLine("Dueño actualizado correctamente.");
                }
                    
               
            }
            static async Task DeleteDueño(int id)
            {
               
                HttpResponseMessage response = await client.DeleteAsync($"api/dueño/DeleteDueño/{id}");

              
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<Clases.ResponseDto>(responseContent);

                    if (apiResponse.IsSuccess == false)
                    {
                        Console.WriteLine($"{apiResponse.Message}");
                    }
                    else
                    {
                        Console.WriteLine("Dueño eliminado correctamente.");
                    }
                    
              
            }

            // Metodos consola Animales
            static async Task GetAnimales()
            {
                
                string animales = null;

                HttpResponseMessage response = await client.GetAsync("api/animal/GetAnimales");

                    string responseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<Clases.ResponseDto>(responseContent);

                    if (apiResponse.IsSuccess == false)
                    {
                        Console.WriteLine($"{apiResponse.Message}");
                    }
                    else
                    {
                        animales = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(animales);
                    }
                   
                              
            }

            static async Task GetAnimal(int id)
            {
                
                string animal = null;

                HttpResponseMessage response = await client.GetAsync($"api/animal/GetAnimal/{id}");

               
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<Clases.ResponseDto>(responseContent);

                    if (apiResponse.IsSuccess == false)
                    {
                        Console.WriteLine($"{apiResponse.Message}");
                    }
                    else
                    {
                        animal = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(animal);
                    }
                    
              

                
            }

            static async Task PostAnimal(string Especie, string Nombre, string Raza, int Edad, string Sexo)
            {
                
                Clases.Animal animal = new Clases.Animal();

                animal.Especie = Especie;
                animal.Nombre = Nombre;
                animal.Raza = Raza;
                animal.Edad = Edad;
                animal.Sexo = Sexo;


                string json = JsonSerializer.Serialize(animal);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("api/animal/PostAnimales", content);

               
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<Clases.ResponseDto>(responseContent);

                    if (apiResponse.IsSuccess == false)
                    {
                        Console.WriteLine($"{apiResponse.Message}");
                    }
                    else
                    {
                        Console.WriteLine("Animal cargado correctamente");
                    }
                    
              
            }
            static async Task PutAnimal(int id, string Especie, string Nombre, string Raza, int Edad, string Sexo)
            {
               
                Clases.Animal animal = new Clases.Animal();

                animal.Especie = Especie;
                animal.Nombre = Nombre;
                animal.Raza = Raza;
                animal.Edad = Edad;
                animal.Sexo = Sexo;

                string json = JsonSerializer.Serialize(animal);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync($"api/animal/PutAnimal/{id}", content);

               
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<Clases.ResponseDto>(responseContent);

                    if (apiResponse.IsSuccess == false)
                    {
                        Console.WriteLine($"{apiResponse.Message}");
                    }
                    else
                    {
                        Console.WriteLine("Animal actualizado correctamente.");
                    }
                    
                         }

            static async Task DeleteAnimal(int id)
            {
               
                HttpResponseMessage response = await client.DeleteAsync($"api/animal/DeleteAnimal/{id}");

              
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<Clases.ResponseDto>(responseContent);

                    if (apiResponse.IsSuccess == false)
                    {
                        Console.WriteLine($"{apiResponse.Message}");
                    }
                    else
                    {
                        Console.WriteLine("Animal eliminado correctamente.");
                    }
                    
              
            }

            static async Task AsignarDueño(int idAnimal, int idDueño)
            {
                
                HttpResponseMessage response = await client.GetAsync($"api/animal/AsignarDueño/{idAnimal}/{idDueño}");
               
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<Clases.ResponseDto>(responseContent);

                    if (apiResponse.IsSuccess == false)
                    {
                        Console.WriteLine($"{apiResponse.Message}");
                    }
                    else
                    {
                        Console.WriteLine("Dueño asignado correctamente.");
                    }
                    
               

            }

            static async Task PostAtencion(int AnimalId, string Motivo, string Tratamiento, DateTime Fecha, string? Medicamentos)
            {
               
                Clases.Atencion atencion = new Clases.Atencion();
                atencion.AnimalId = AnimalId;
                atencion.Motivo = Motivo;
                atencion.Tratamiento = Tratamiento;
                atencion.Fecha = Fecha;
                atencion.Medicamentos = Medicamentos;

                string json = JsonSerializer.Serialize(atencion);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync($"api/atencion/PostAtenciones", content);

               
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<Clases.ResponseDto>(responseContent);
                    
                    if (apiResponse.IsSuccess==false)
                    {
                        Console.WriteLine($"{apiResponse.Message}");
                    }
                    else
                    {
                        Console.WriteLine("Atencion registrada correctamente");
                    }
               
            }

            static async Task GetMedicamento(int id)
            {
              
                string atencion = null;

                HttpResponseMessage response = await client.GetAsync($"api/atencion/GetMedicamento/{id}");

                
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<Clases.ResponseDto>(responseContent);

                    if (apiResponse.IsSuccess == false)
                    {
                        Console.WriteLine($"{apiResponse.Message}");
                    }
                    else
                    {
                        atencion = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(atencion);
                    }
                    
              

                
            }


        }
    }
}