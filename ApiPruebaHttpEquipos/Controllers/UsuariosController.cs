using AccesoDatos.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ApiPruebaHttpEquipos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly DbContext _dbContext;
        public UsuariosController(DbContext dbcontext)
        {


            _dbContext = dbcontext;

        }

        [HttpGet]

        public async Task<IActionResult> getUsuarios()
        {

            var traerUsuario = await _dbContext.GetAllUsuarios();
            return Ok(traerUsuario);

        }


        [HttpGet("{id}")]

        public async Task<IActionResult> getId(int id)
        {
            var traerid = await _dbContext.TraerPorId(id); 

            return Ok(traerid);


        }


        [HttpPatch("actualizar{id}")]

        public async Task<IActionResult> getActualizar(int id, [FromBody] string nombre_usuario)
        {
            var traercampo = await _dbContext.ActualizzarCampo(id,nombre_usuario );

            return Ok(traercampo);


        }

    }
}
