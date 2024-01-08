using Microsoft.AspNetCore.Mvc;
using AccesoDatos.Repositorios;
namespace ApiPruebaHttpEquipos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActualizarEdadController : ControllerBase
    {
        private readonly DbContext _dbContext;

        public ActualizarEdadController(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSet(int id, int NuevaEdad)
        {
            var actulizando = await _dbContext.ActualizarEdad(id, NuevaEdad);
            return Ok(actulizando);
        }       
    }
}
