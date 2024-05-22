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

        static HttpClient client = new HttpClient();
        static async Task Main()
        {
            Console.WriteLine(DeleteDueño(18));
            Console.WriteLine(PutDueño(16, 44766433, "Fly", "OK", "3888888"));
            Console.WriteLine(GetDueño(3));
            Console.WriteLine(GetDueños());
            Console.WriteLine(PostDueño(44766433, "Fly", "Fl", "65858658"));
            
            Console.ReadLine();
        }
        static async Task GetDueños()
        {
            client.BaseAddress = new Uri("https://localhost:7072/");

            string dueños = null;

            HttpResponseMessage response = await client.GetAsync("api/dueño/GetDueños");

            if (response.IsSuccessStatusCode)
            {
                dueños = await response.Content.ReadAsStringAsync();
            }
            Console.WriteLine(dueños);
        }
        static async Task GetDueño(int id)
        {
            client.BaseAddress = new Uri("https://localhost:7072/");

            string dueño = null;

            HttpResponseMessage response = await client.GetAsync($"api/dueño/GetDueño/{id}"); 

            if (response.IsSuccessStatusCode)
            {
                dueño = await response.Content.ReadAsStringAsync();
            }

            Console.WriteLine(dueño);
        }
        static async Task PostDueño(int Dni, string Nombre, string Apellido, string Telefono)
        {
            client.BaseAddress = new Uri("https://localhost:7072/");

            Clases.Dueño dueño = new Clases.Dueño();

            dueño.Dni = Dni;
            dueño.Nombre = Nombre;
            dueño.Apellido = Apellido;
            dueño.Telefono = Telefono;

            string json = JsonSerializer.Serialize(dueño);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("api/dueño/PostDueños", content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Dueño cargado correctamente");
            }
        }
        static async Task PutDueño(int id, int Dni, string Nombre, string Apellido, string Telefono)
        {
            client.BaseAddress = new Uri("https://localhost:7072/");

            Clases.Dueño dueño = new Clases.Dueño();

            dueño.Dni = Dni;
            dueño.Nombre = Nombre;
            dueño.Apellido = Apellido;
            dueño.Telefono = Telefono;

            string json = JsonSerializer.Serialize(dueño);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync($"api/dueño/PutDueño/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Dueño actualizado correctamente.");
            }
        }
        static async Task DeleteDueño(int id)
        {
            client.BaseAddress = new Uri("https://localhost:7072/");

            HttpResponseMessage response = await client.DeleteAsync($"api/dueño/DeleteDueño/{id}");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Dueño eliminado correctamente.");
            }
        }

    }
}

//Clases.Dueño dueño = new Clases.Dueño();
//dueño.Id = 13;
//dueño.Dni = 2;
//dueño.Apellido = "fdfd";
//dueño.Nombre = "dj";
//dueño.Telefono = "242432";