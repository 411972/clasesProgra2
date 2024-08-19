using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase_1
{
    public class Pack : Producto
    {
        public int Cantidad{ get; set; }

        public Pack(int cantidad, int codigo, string nombre, double precio):base(codigo, nombre, precio) {
            Cantidad = cantidad;
        }

        public override double CalcularPrecio()
        {
            return Cantidad * Precio;
        }
    }
}
