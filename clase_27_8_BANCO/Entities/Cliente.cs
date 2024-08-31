using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase_27_8_BANCO.Entities
{
    public class Cliente
    {
        public int ID_CLIENTE { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }    
        public int DNI { get; set; }

        public List<Cuentas> Cuentas { get; set; }

        public override string ToString()
        {
            return "Nombre: " + NOMBRE + " Apellido: " + APELLIDO;
        }
        

    }
}
