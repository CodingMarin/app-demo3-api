using app_demo3_api.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace app_demo3_api.Data
{
    public class CRUDEstudiante: IEstudiante
    {
        private Configuracion _conexion;

        public CRUDEstudiante(Configuracion conexion)
        {
            _conexion = conexion;
        }

        public MySqlConnection Conectar()
        {
            return new MySqlConnection(_conexion.Conectar);
        }

        public async Task<bool> RegistrarEstudiante(Estudiante estudiante)
        {
            var db = Conectar();
            String procedure_sql = "sp_crear_estudiantes";

            int n = await db.ExecuteAsync(procedure_sql, new
            {
                id_estudiante_param = estudiante.id_estudiante,
                nombre_param = estudiante.nombre,
                apellido_param = estudiante.apellido,
                email_param = estudiante.email,
                telefono_param = estudiante.telefono,
                direccion_param = estudiante.direccion,
                fecha_nacimiento_param = estudiante.fecha_nacimiento
            }, commandType: CommandType.StoredProcedure);
            return n > 0;
        }

        public async Task<bool> EliminarEstudiante(string idEstudiante)
        {
            var db = Conectar();
            string procedure_sql = "sp_eliminar_estudiantes";

            int n = await db.ExecuteAsync(procedure_sql, new
            {
                id_estudiante_param = idEstudiante
            }, commandType: CommandType.StoredProcedure);

            return n > 0;
        }


        public async Task<Estudiante> ListarEstudianteById(string idEstudiante)
        {
            var db = Conectar();
            string procedure_sql = "sp_buscar_por_id_estudiantes";

           return await db.QueryFirstOrDefaultAsync<Estudiante>(procedure_sql,
                new { 
                    id_estudiante_param = idEstudiante 
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Estudiante>> ListarEstudiante()
        {
            var db = Conectar();
            string procedure_sql = "sp_leer_estudiantes";

            return await db.QueryAsync<Estudiante>(procedure_sql, commandType: CommandType.StoredProcedure);
        }


        public async Task<bool> ActualizarEstudiante(Estudiante estudiante)
        {
            var db = Conectar();
            string procedure_sql = "sp_actualizar_estudiante";

            int affectedRows = await db.ExecuteAsync(procedure_sql, new
            {
                id_estudiante_param = estudiante.id_estudiante,
                nombre_param = estudiante.nombre,
                apellido_param = estudiante.apellido,
                email_param = estudiante.email,
                telefono_param = estudiante.telefono,
                direccion_param = estudiante.direccion,
                fecha_nacimiento_param = estudiante.fecha_nacimiento
            }, commandType: CommandType.StoredProcedure);

            return affectedRows > 0;
        }

    }
}
