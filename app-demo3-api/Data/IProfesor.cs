using app_demo3_api.Model;

namespace app_demo3_api.Data
{
    public interface IProfesor
    {
        Task<IEnumerable<Profesor>> ListarProfesor();
        Task<Profesor> ListarProfesorById(String idProfesor);
        Task<bool> RegistraProfesor(Profesor profesor);
        Task<bool> ActualizarProfesor(Profesor profesor);
        Task<bool> EliminarProfesor(String idProfesor);
    }
}
