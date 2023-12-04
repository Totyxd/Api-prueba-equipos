using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaHttpEquipos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EquiposController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetEquiposPrueba()
        {
            var equipos = await EquiposConsumer.GetEquiposData("http://gemsa.ddns.net:8035/api/Equipo/TraerEquipos");
            return Ok(equipos);
        }

        //Controlador para /api/Equipo/{id}
        //Controlador para /api/DatoEquipo/traerdiscos
        //Contolador para /api/DatoEquipo/traermadre
        //Controlador para /api/DatoEquipo/traeroffice
        //Controlador para /api/DatoEquipo/traerprocesadores
    };
}