using ProductosAPI.Models;

namespace ProductosAPI.Services
{
    public interface IAplicacion
    {
        List<Producto> getProducts();

        bool AgregarProducto(Producto p);

        bool EditarProducto(Producto p);
        bool EliminarProducto(int codigo);

    }
}
