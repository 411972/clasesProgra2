using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase_27_8_BANCO.Entities
{
    public class Cuentas
    {
        public int ID_CUENTA { get; set; }
        public string CBU { get; set; }
        public double SALDO { get; set; }

        public int TIPO_CUENTA { get; set; }

        public DateTime ULTIMO_MOV { get; set; }
    }
}
