using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase_1
{
    public class Suelto :Producto
    {

        public int Medida { get; set; }

        public Suelto(int medida,int codigo, string nombre, double precio) : base(codigo, nombre, precio)
        {
            Medida = medida;
        }
        public override double CalcularPrecio()
        {
            return Precio * Medida;
        }
    }
}
