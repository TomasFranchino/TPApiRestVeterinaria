using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppVeterinaria.Data;
using WebAppVeterinaria.DTO;
using WebAppVeterinaria.Models;

namespace WebAppVeterinaria.Controllers
{
    [ApiController]
    [Route("api/animal")]
    public class AnimalesController : ControllerBase
    {

        private readonly AppDbContext _context;
        private ResponseDto _response;

        public AnimalesController(AppDbContext context)
        {
            _context = context;
            _response = new ResponseDto();
        }
    

        [HttpPost("PostAnimales")]
        public ResponseDto PostAnimal([FromBody] DTOAnimal.PostDTOAnimal animal)
        {
            try
            {
                Animal anim = new Animal();
                anim.Raza= animal.Raza;
                anim.Edad= animal.Edad;
                anim.Especie= animal.Especie;
                anim.Sexo= animal.Sexo;
                anim.Nombre= animal.Nombre;
                _context.Animal.Add(anim);
                _context.SaveChanges();

                _response.Data = animal;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("GetAnimales")]
        public ResponseDto GetAnimales()
        {
            try
            {
                IEnumerable<Animal> animales = _context.Animal.ToList();
                _response.Data = animales;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("GetAnimal/{id}")]
        public ResponseDto GetAnimal(int id)
        {
            try
            {
                Animal animal = _context.Animal.FirstOrDefault(x=>x.Id==id);
                if (animal == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Animal no encontrado.";
                    return _response;
                }
                _response.Data = animal;
                
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut("AsignarDueño")]
        public ResponseDto AsignarDueño(int idAnimal, int idDueño)
        {
            try
            {
                Animal animal = _context.Animal.FirstOrDefault(x => x.Id == idAnimal);
                Dueño dueño = _context.Dueño.FirstOrDefault(x => x.Id == idDueño);

                if (animal == null || dueño == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Animal o dueño no encontrado.";
                    return _response;
                }

                animal.DueñoId = idDueño;

                _context.Animal.Update(animal);
                _context.Dueño.Update(dueño);
                _context.SaveChanges();

                _response.Data = animal;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }
        [HttpPut("PutAnimal")]
        public ResponseDto PutAnimal([FromBody] DTOAnimal.PutDTOAnimal animal, int idAnimal)
        {
            try
            {     
                Animal anim = _context.Animal.FirstOrDefault(x=> x.Id == idAnimal);
                if(anim == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Animal no encontrado.";
                    return _response;
                }
                anim.Nombre = animal.Nombre;
                anim.Edad = animal.Edad;
                anim.DueñoId = animal.IdDueño;
                anim.Especie = animal.Especie;
                anim.Raza= animal.Raza;
                anim.Sexo = animal.Sexo;
                _context.Animal.Update(anim);
                _context.SaveChanges();

                _response.Data = animal;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete("DeleteAnimal/{id}")]
        public ResponseDto DeleteAnimal(int id)
        {
            try
            {
                var animal = _context.Animal.Where(x=>x.Id==id).FirstOrDefault();
                if (animal == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Animal no encontrado.";
                    return _response;
                }
                _context.Animal.Remove(animal);
                _context.SaveChanges();
               
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        }
    }

