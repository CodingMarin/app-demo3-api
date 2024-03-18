using app_demo3_api.Model;

namespace app_demo3_api.Data
{
    public interface IProducto
    {
        Task<IEnumerable<Producto>> ListarProducto();
        Task<Producto> MostrarProducto(String codigo);
        Task<bool> RegistrarProducto(Producto producto);
        Task<bool> ActualizarProducto(Producto producto);
        Task<bool> EliminarProducto(String codigo);
    }
}
