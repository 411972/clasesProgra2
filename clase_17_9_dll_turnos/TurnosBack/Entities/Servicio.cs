﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnosBack.Entities
{
    public class Servicio
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int Costo { get; set; }

        public string EnPromocion { get; set; }
    }
}
