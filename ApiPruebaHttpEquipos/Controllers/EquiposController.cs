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
            try
            {
                var equipos = await EquiposConsumer.GetEquiposData(url:"http://gemsa.ddns.net:8035/api/Equipo/");
                return Ok(equipos);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Error del servidor: {ex.Message}");
            }
        }

         
    };
}