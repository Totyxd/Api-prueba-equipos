using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaHttpEquipos.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProcesadoresController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetEquiposProcesadores()
        {
            try
            {
                var procesadores = await EquiposConsumer.GetEquiposData("http://gemsa.ddns.net:8035/api/DatoEquipo/traerprocesadores");
                return Ok(procesadores);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error del servidor: {ex.Message}");
            }
        }
    }
}

