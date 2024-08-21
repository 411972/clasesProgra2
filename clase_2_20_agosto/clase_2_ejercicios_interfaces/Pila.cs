using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase_2_ejercicios_interfaces
{
    public class Pila : IColleccion
    {
        public Object[] elementos;
        int contador;

        public Pila(int tamanio)
        {
            elementos = new Object[tamanio];
            contador = 0;

        }
        public bool añadir(object obj)
        {
            if (contador < elementos.Length)
            {
                elementos[contador] = obj;
                contador++;
                return true;
            }
            else{
                return false;
            };
        }

        public bool estaVacia()
        {
            if(contador == 0)
            {
                return true;
            }
            else
            {
                return false;
            };
        }

        public object extraer()
        {
            object first = elementos[0];
            Console.WriteLine(first);   
            for(int i = 0; i< contador ; i++)
            {
                if(i != elementos.Length - 1)
                {
                    elementos[i] = elementos[i + 1];
                    
                }else
                {
                    elementos[i] = null;
                }      
            }
            contador--;
            return first;
        }

        public object primero()
        {
            return elementos[0];
        }
    }
}
