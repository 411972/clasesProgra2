using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase_2_ejercicios_interfaces
{
    public class Cola : IColleccion
    {
        public List<Object> Elementos { get; set; }
        public Cola()
        {
            Elementos = new List<Object>();
        }
        public bool añadir(object obj)
        {
            if(obj != null)
            {
                Elementos.Add(obj);
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool estaVacia()
        {
            if(Elementos.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object extraer()
        {
            object first = Elementos[0];
            Elementos.RemoveAt(0);
            return first;
        }

        public object primero()
        {
            return Elementos.First();
        }
    }
}
