using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnosBack.Entities
{
    public class Turno
    {
        public int IdTurno { get; set; }

        public string Fecha { get; set; }

        public string Hora { get; set; }

        public string Cliente { get; set; }

        public List<DetalleTurno> Detalles { get; set; }

        public Turno()
        {
            Detalles = new List<DetalleTurno>();
        }
    }
}
