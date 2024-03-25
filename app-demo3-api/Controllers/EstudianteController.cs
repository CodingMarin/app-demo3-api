using app_demo3_api.Data;
using app_demo3_api.Model;
using Microsoft.AspNetCore.Mvc;

namespace app_demo3_api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    public class EstudianteController : Controller
    {
        private readonly IEstudiante _estudiante;

        public EstudianteController(IEstudiante estudiante)
        {
            _estudiante = estudiante;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarEstudiante(Estudiante estudiante)
        {
            bool resultado = await _estudiante.RegistrarEstudiante(estudiante);

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
        public async Task<IActionResult> EliminarEstudiante(string id)
        {
            bool resultado = await _estudiante.EliminarEstudiante(id);

            if (!resultado)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> ObtenerEstudiantePorId(string id)
        {
            var estudiante = await _estudiante.ListarEstudianteById(id);

            if (estudiante == null)
            {
                return NotFound();
            }

            return estudiante;
        }

        [HttpGet]
        public async Task<IEnumerable<Estudiante>> ListarEstudiantes()
        {
            return await _estudiante.ListarEstudiante();
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarEstudiante([FromBody] Estudiante estudiante)
        {
            bool resultado = await _estudiante.ActualizarEstudiante(estudiante);

            if (!resultado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
