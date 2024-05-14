using Microsoft.AspNetCore.Mvc;
using WebAppVeterinaria.Models;

namespace WebAppVeterinaria.Controllers
{
    public class AtencionController : ControllerBase
    {
        [HttpGet]
        public List<Atencion> ConsultarAnimales()
        {
            return Models.Repositorio.atencionList;
        }

        [HttpPost]
        public ActionResult CrearAtencion(Atencion atencion)
        {
            Models.Repositorio.atencionList.Add(atencion);
            return Ok();
        }
    }
}
