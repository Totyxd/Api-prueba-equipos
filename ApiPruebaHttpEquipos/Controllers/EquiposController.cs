using ApiPruebaHttpEquipos;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]")]

public class EquipoController : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEquiposId(int id)
    {
        try
        {
            var identificador = await EquiposConsumer.GetEquiposData($"http://gemsa.ddns.net:8035/api/Equipo/{id}");
            return Ok(identificador);
        }
        catch (Exception ex)
        {
            // Manejo de errores
            return StatusCode(500, $"Error del servidor: {ex.Message}");
        }
    }
}