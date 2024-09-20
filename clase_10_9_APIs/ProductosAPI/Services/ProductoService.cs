using ProductosAPI.Models;
using System.Collections.Generic;

namespace ProductosAPI.Services
{
    public class ProductoService : IAplicacion
    {
        public static List<Producto> productos{ get; set; }
        public bool AgregarProducto(Producto p)
        {
            bool result = false;
            if(p != null)
            {
                productos.Add(p);
            }
            return result;
        }

        public bool EditarProducto(Producto p)
        {
            throw new NotImplementedException();
        }

        public bool EliminarProducto(int codigo)
        {
            var p = productos.Find(p => p.Codigo == codigo);
            if (p != null)
            {
                productos.Remove(p);
                return true;
            }
            return false;
        }


    public List<Producto> getProducts()
        {
        return productos;
        }
    }
}
