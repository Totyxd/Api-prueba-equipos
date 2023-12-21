using AccesoDatos.Entidades;
using AccesoDatos.Repositorios.Prueba;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaHttpEquipos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private readonly RepositorioSucursales _repositorioSucursales;
        public SucursalesController(RepositorioSucursales repositorioSucursales)
        {
            _repositorioSucursales = repositorioSucursales;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _repositorioSucursales.TraerTodosAsync();
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] string nombre)
        {
            Sucursal suc = new Sucursal();
            suc.nombre = nombre;
            var res = await _repositorioSucursales.AgregarAsync(suc);
            return Ok(res);
        }
    }
}
