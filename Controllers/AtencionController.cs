using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppVeterinaria.Data;
using WebAppVeterinaria.DTO;
using WebAppVeterinaria.Models;

namespace WebAppVeterinaria.Controllers
{
    public class AtencionController : ControllerBase
    {
        private readonly AppDbContext _context;
        private ResponseDto _response;

        public AtencionController(AppDbContext context)
        {
            _context = context;
            _response = new ResponseDto();
        }

        [HttpPost("PostAtenciones")]
        public ResponseDto PostAtencion([FromBody] DTOAtencion.PostDTOAtencion atencion)
        {
            try
            {
                Atencion aten = new Atencion();
                DateTime FechaDeRegistro = DateTime.Now;
                TimeSpan ValidacionFecha = FechaDeRegistro - atencion.Fecha;
               if(ValidacionFecha.TotalDays<30)
                {
                    aten.AnimalId= atencion.AnimalId;
                    Animal animal = _context.Animal.FirstOrDefault(x => x.Id == atencion.AnimalId);
                    if (animal == null) 
                    {
                        _response.IsSuccess = false;
                        _response.Message = "El animal a registrar la atención no existe o esta mal ingresado.";
                        return _response;
                    }
                    aten.Animal = animal;
                    aten.Tratamiento = atencion.Tratamiento;
                    aten.Medicamentos = atencion.Medicamentos;
                    aten.Fecha = atencion.Fecha;
                    aten.Motivo = atencion.Motivo;
                    _context.Atenciones.Add(aten);
                    _context.SaveChanges();
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.Message = "La atencion ocurrio hace mas de 30 dias.";
                    return _response;
                }
                _response.Data = aten;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("GetAtenciones")]
        public ResponseDto GetAtenciones()
        {
            try
            {
                IEnumerable<Atencion> atenciones = _context.Atenciones.ToList();
                _response.Data = atenciones;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("GetAtencion/{id}")]
        public ResponseDto GetAtencion(int id)
        {
            try
            {
                Atencion atencion = _context.Atenciones.FirstOrDefault(x => x.Id == id);
                if (atencion == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Atención no encontrada.";
                    return _response;
                }
                _response.Data = atencion;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("GetAtencionesXAnimal/{idAnimal}")]
        public ResponseDto GetAtencionesXAnimal(int idAnimal)
        {
            try
            {
                IEnumerable<Atencion> atencion = _context.Atenciones.Where(x => x.AnimalId == idAnimal);
                if (atencion.Count() == 0)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Atenciónes no encontradas.";
                    return _response;
                }
                _response.Data = atencion;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpPut("PutAtencion")]
        public ResponseDto PutAtencion([FromBody] DTOAtencion.PutDTOAtencion atencion, int idAtencion)
        {
            try
            {
                Atencion aten = _context.Atenciones.Where(x => x.Id == idAtencion).FirstOrDefault();
                Animal animal = _context.Animal.FirstOrDefault(x => x.Id == atencion.AnimalId);
                if (aten == null || animal == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "El animal y/o atencion a modificar no existen o están mal ingresados.";
                    return _response;
                }
                aten.Animal =animal;
                aten.AnimalId = atencion.AnimalId;
                aten.Motivo = atencion.Motivo;
                aten.Fecha = atencion.Fecha;;
                aten.Medicamentos = atencion.Medicamentos;
                aten.Tratamiento = atencion.Tratamiento;
                
                _context.Atenciones.Update(aten);
                _context.SaveChanges();

                _response.Data = aten;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpDelete("DeleteAtencion/{id}")]
        public ResponseDto DeleteAtencion(int id)
        {
            try
            {
                Atencion atencion = _context.Atenciones.Where(x => x.Id == id).FirstOrDefault();
                if (atencion == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Atención no encontrada.";
                    return _response;
                }
                _context.Atenciones.Remove(atencion);
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
