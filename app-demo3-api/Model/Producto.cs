namespace app_demo3_api.Model
{
    public class Producto
    {
        public String? codigo_producto { get; set; }
        public String? producto { get; set; }
        public char medida { get; set; }
        public int stock_disponible { get; set; }
        public char perecible { get; set; }
        public float costo { get; set; }
        public String? producto_codigo_marca { get; set; }
        public String? producto_codigo_presentacion { get; set; }
    }
}
