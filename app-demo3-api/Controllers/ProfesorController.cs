using app_demo3_api.Data;
using app_demo3_api.Model;
using Microsoft.AspNetCore.Mvc;

namespace app_demo3_api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    public class ProfesorController : Controller
    {
        private readonly IProfesor _profesor;

        public ProfesorController(IProfesor profesor)
        {
            _profesor = profesor;
        }

        [HttpPost]
        public async Task<IActionResult> RegistraProfesor(Profesor estudiante)
        {
            bool resultado = await _profesor.RegistraProfesor(estudiante);

            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarProfesor(string id)
        {
            bool resultado = await _profesor.EliminarProfesor(id);

            if (!resultado)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Profesor>> ObtenerProfesorPorId(string id)
        {
            var profesor = await _profesor.ListarProfesorById(id);

            if (profesor == null)
            {
                return NotFound();
            }

            return profesor;
        }

        [HttpGet]
        public async Task<IEnumerable<Profesor>> ListarProfesor()
        {
            return await _profesor.ListarProfesor();
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarProfesor([FromBody] Profesor profesor)
        {
            bool resultado = await _profesor.ActualizarProfesor(profesor);

            if (!resultado)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
