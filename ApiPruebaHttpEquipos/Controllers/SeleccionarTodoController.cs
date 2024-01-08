using AccesoDatos.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
namespace ApiPruebaHttpEquipos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeleccionarTodoController:ControllerBase
    {
        private readonly DbContext _dbContext;

        public SeleccionarTodoController(DbContext dbContext)
        {
             _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var seleccionar = await _dbContext.Obtenertodo();
            return Ok(seleccionar);
        }

        }
    }

