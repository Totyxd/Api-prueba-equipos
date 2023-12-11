using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaHttpEquipos.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TraerDiscoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetEquiposDisco()
        {
            try
            {
                var disco = await EquiposConsumer.GetEquiposData("http://gemsa.ddns.net:8035/api/DatoEquipo/traerdiscos");
                return Ok(disco);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error del servidor: {ex.Message}");
            }
        }
    }





}
