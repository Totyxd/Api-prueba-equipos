using ApiPruebaHttpEquipos;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]/[Action]")]
public class DatoEquipoController : ControllerBase
{
    private async Task<IActionResult> ObtenerDatosApi(string apiUrl)
    {
        try
        {
            var identificador = await EquiposConsumer.GetEquiposData(apiUrl);
            return Ok(identificador);
        }
        catch (Exception ex)
        {
            // Manejo de errores
            return StatusCode(500, $"Error del servidor: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<IActionResult> TraerDiscos()
    {
        return await ObtenerDatosApi("http://gemsa.ddns.net:8035/api/DatoEquipo/traerdiscos");
    }

    [HttpGet]
    public async Task<IActionResult> TraerMadre()
    {
        return await ObtenerDatosApi("http://gemsa.ddns.net:8035/api/DatoEquipo/traermadre");
    }


    [HttpGet]
    public async Task<IActionResult> TraerOffice()
    {
        return await ObtenerDatosApi("http://gemsa.ddns.net:8035/api/DatoEquipo/traeroffice");
    }

    [HttpGet]
    public async Task<IActionResult> TraerProcesadores()
    {
        return await ObtenerDatosApi("http://gemsa.ddns.net:8035/api/DatoEquipo/traerprocesadores");
    }

}