using Microsoft.AspNetCore.Mvc;
using AccesoDatos.Repositorios;

namespace ApiPruebaHttpEquipos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObtenerIdController : ControllerBase
    {

        private readonly DbContext _dbContext;

        public ObtenerIdController(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(int id)
        {
            var identificador = await _dbContext.ObtenerId(id);

            return Ok(identificador);
        }
    } 
}
