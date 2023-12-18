using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaHttpEquipos.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class TraerMadreControllers : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetEquiposMadre()
        {
            try
            {
                var traerMadre = await EquiposConsumer.GetEquiposData("http://gemsa.ddns.net:8035/api/DatoEquipo/traermadre");
                return Ok(traerMadre);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error del servidor: {ex.Message}");
            }
        }
    }
}
