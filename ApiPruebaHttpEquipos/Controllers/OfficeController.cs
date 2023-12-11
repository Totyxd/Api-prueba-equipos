using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaHttpEquipos.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OfficeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetEquiposOffice()
        {
            try
            {
                var office = await EquiposConsumer.GetEquiposData("http://gemsa.ddns.net:8035/api/DatoEquipo/traeroffice");
                return Ok(office);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error del servidor: {ex.Message}");
            }
        }
    }
}
