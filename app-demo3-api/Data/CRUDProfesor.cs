using app_demo3_api.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace app_demo3_api.Data
{
    public class CRUDProfesor: IProfesor
    {
        private Configuracion _conexion;

        public CRUDProfesor(Configuracion conexion)
        {
            _conexion = conexion;
        }

        public MySqlConnection Conectar()
        {
            return new MySqlConnection(_conexion.Conectar);
        }

        public async Task<bool> ActualizarProfesor(Profesor profesor)
        {
            var db = Conectar();
            string procedure_sql = "actualizar_profesor";

            int affectedRows = await db.ExecuteAsync(procedure_sql, new
            {
                id_profesor_original = profesor.id_profesor,
                nuevo_id_profesor = profesor.id_profesor,
                nuevo_nombre = profesor.nombre,
                nuevo_apellido = profesor.apellido,
                nuevo_email = profesor.email,
                nuevo_telefono = profesor.telefono,
            }, commandType: CommandType.StoredProcedure);

            return affectedRows > 0;
        }

        public async Task<bool> EliminarProfesor(string idProfesor)
        {
            var db = Conectar();
            string procedure_sql = "eliminar_profesor_por_id";

            int n = await db.ExecuteAsync(procedure_sql, new
            {
                id_profesor = idProfesor
            }, commandType: CommandType.StoredProcedure);

            return n > 0;
        }

        public async Task<IEnumerable<Profesor>> ListarProfesor()
        {
            var db = Conectar();
            string procedure_sql = "mostrar_profesores";

            return await db.QueryAsync<Profesor>(procedure_sql, commandType: CommandType.StoredProcedure);
        }

        public async Task<Profesor> ListarProfesorById(string idProfesor)
        {
            var db = Conectar();
            string procedure_sql = "mostrar_profesor_por_id";

            return await db.QueryFirstOrDefaultAsync<Profesor>(procedure_sql,
                 new
                 {
                     id_profesor_param = idProfesor
                 },
                 commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> RegistraProfesor(Profesor profesor)
        {
            var db = Conectar();
            String procedure_sql = "registrar_profesor";

            int n = await db.ExecuteAsync(procedure_sql, new
            {
                id_profesor = profesor.id_profesor,
                nombre = profesor.nombre,
                apellido = profesor.apellido,
                email = profesor.email,
                telefono = profesor.telefono,
            }, commandType: CommandType.StoredProcedure);
            return n > 0;
        }
    }
}
