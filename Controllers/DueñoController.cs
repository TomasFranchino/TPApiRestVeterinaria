using Microsoft.AspNetCore.Mvc;
using WebAppVeterinaria.Data;
using WebAppVeterinaria.DTO;
using WebAppVeterinaria.Models;

namespace WebAppVeterinaria.Controllers
{
    [ApiController]
    [Route("api/dueño")]

    public class DueñoController : ControllerBase
    {
        private readonly AppDbContext _context;
        private ResponseDto _response;

        public DueñoController(AppDbContext context)
        {
            _context = context;
            _response = new ResponseDto();
        }


        [HttpPost("PostDueños")]
        public ResponseDto PostDueños([FromBody] DTODueño.PostDTODueño dueño)
        {
            try
            {
                Dueño due = new Dueño();
                due.Nombre = dueño.Nombre;
                due.Apellido = dueño.Apellido;
                due.Dni = dueño.Dni;
                due.Telefono = dueño.Telefono;

                
                _context.Dueño.Add(due);
                _context.SaveChanges();

                _response.Data = dueño;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("GetDueños")]
        public ResponseDto GetDueños()
        {
            try
            {
                IEnumerable<Dueño> dueño = _context.Dueño.ToList();
                _response.Data = dueño;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("GetDueño/{id}")]
        public ResponseDto GetDueño(int id)
        {
            try
            {
                Dueño dueño = _context.Dueño.FirstOrDefault(x => x.Id == id);
                _response.Data = dueño;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut("PutDueño")]
        public ResponseDto PutDueño([FromBody] Dueño dueño)
        {
            try
            {
                _context.Dueño.Update(dueño);
                _context.SaveChanges();

                _response.Data = dueño;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete("DeleteDueño/{id}")]
        public ResponseDto DeleteAnimal(int id)
        {
            try
            {
                var dueño = _context.Dueño.Where(x => x.Id == id).FirstOrDefault();
                _context.Dueño.Remove(dueño);
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

