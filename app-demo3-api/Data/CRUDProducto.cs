using app_demo3_api.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace app_demo3_api.Data
{
    public class CRUDProducto : IProducto
    {
        private Configuracion _conexion;

        public CRUDProducto(Configuracion conexion)
        {
            _conexion = conexion;
        }

        public MySqlConnection Conectar()
        {
            return new MySqlConnection(_conexion.Conectar);
        }

        public async Task<bool> ActualizarProducto(Producto producto)
        {
            var db = Conectar();
            String cad_sql = @"update tb_producto set
                             producto = @prod, medida = @med, stock_disponible = @stk,
                             perecible = @prc, costo = @cst, producto_codigo_marca = @cod_mar
                             producto_codigo_presentacion = @cod_pre where codigo_producto = @cod";

            int n = await db.ExecuteAsync(cad_sql, new {
                cod = producto.codigo_producto, prod = producto.producto,
                med = producto.medida, stk = producto.stock_disponible,
                prc = producto.perecible, cst = producto.costo,
                cod_mar = producto.producto_codigo_marca,
                cod_pre = producto.producto_codigo_presentacion
            });

            return n > 0;
        }

        public async Task<bool> EliminarProducto(string codigo)
        {
            var db = Conectar();

            String cad_sql = @"delete from tb_producto
                             where codigo_producto = @cod";

            int n = await db.ExecuteAsync(cad_sql, new { cod = codigo });

            return n > 0;
        }

        public async Task<IEnumerable<Producto>> ListarProducto()
        {
            var db = Conectar();

            String cad_sql = @"select * from tb_producto";

            return await db.QueryAsync<Producto>(cad_sql, new { });
        }

        public async Task<Producto> MostrarProducto(string codigo)
        {
            var db = Conectar();

            String cad_sql = @"select * from tb_producto where codigo_producto = @cod";

            return await db.QueryFirstAsync<Producto>(cad_sql, new {cod = codigo });

        }

        public async Task<bool> RegistrarProducto(Producto producto)
        {
            var db = Conectar();

            String cad_sql = @"insert into tb_producto values
                             (@cod, @prod, @med, @stk, @prc, @cst, @cod_mar, @cod_pre)";

            int n = await db.ExecuteAsync(cad_sql, new
            {
                cod = producto.codigo_producto, prod = producto.producto,
                med = producto.medida, stk = producto.stock_disponible,
                prc = producto.perecible, cst = producto.costo,
                cod_mar = producto.producto_codigo_marca,
                cod_pre = producto.producto_codigo_presentacion
            });
            return n > 0;
        }
    }
}
