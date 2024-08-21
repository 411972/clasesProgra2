using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase_2_ejercicios_interfaces
{
    public interface IColleccion
    {
        bool estaVacia();
        Object extraer();
        Object primero();
        bool añadir(object obj);
    }
}
