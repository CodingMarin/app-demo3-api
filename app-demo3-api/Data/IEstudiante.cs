using app_demo3_api.Model;

namespace app_demo3_api.Data
{
    public interface IEstudiante
    {
        Task<IEnumerable<Estudiante>> ListarEstudiante();
        Task<Estudiante> ListarEstudianteById(String idEstudiante);
        Task<bool> RegistrarEstudiante(Estudiante estudiante);
        Task<bool> ActualizarEstudiante(Estudiante estudiante);
        Task<bool> EliminarEstudiante(String idEstudiante);
    }
}
