using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaHttpEquipos.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class EquiposIdControllers : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEquiposId(int id)
        {
            try
            {
                var identificador = await EquiposConsumer.GetEquiposData($"http://gemsa.ddns.net:8035/api/Equipo/9{id}");
                return Ok(identificador);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error del servidor: {ex.Message}");
            }
        }
    }
}
