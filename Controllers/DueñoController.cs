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
                if (dueño == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Dueño no encontrado.";
                    return _response;
                }
                _response.Data = dueño;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("ListarAnimalesDeUnDueño/{idDueño}")]
        public ResponseDto ListarAnimalesDeUnDueño(int idDueño)
        {
            try
            {
                IEnumerable<Animal> animalesdeundueño = _context.Animal.Where(x => x.DueñoId == idDueño).ToList();
                if (animalesdeundueño.Count() == 0)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Este Dueño aun no posee animales o introdujo mal el id del dueño.";
                    return _response;
                }
                _response.Data = animalesdeundueño;
            }
            catch (Exception ex) 
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

             return _response;

        }


        [HttpPut("PutDueño/{idDueño}")]
        public ResponseDto PutDueño([FromBody] DTODueño.PutDTODueño dueño,int IdDueño)
        {
            try
            {
                Dueño due = _context.Dueño.FirstOrDefault(x=> x.Id == IdDueño);
                if (due==null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Dueño no encontrado.";
                    return _response;
                }

                due.Nombre = dueño.Nombre;
                due.Telefono = dueño.Telefono;
                due.Apellido = dueño.Apellido;
                due.Dni = dueño.Dni;

                _context.Dueño.Update(due);
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
        public ResponseDto DeleteDueño(int id)
        {
            try
            {
                var dueño = _context.Dueño.Where(x => x.Id == id).FirstOrDefault();
                if (dueño == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Dueño no encontrado.";
                    return _response;
                }
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

