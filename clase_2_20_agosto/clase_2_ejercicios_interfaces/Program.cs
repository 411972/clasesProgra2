// See https://aka.ms/new-console-template for more information
using clase_2_ejercicios_interfaces;


Pila pila = new Pila(3);

Console.WriteLine("Ejercicio 'Pilas'");
Console.WriteLine("------------");

Console.WriteLine("Al principio está vacio: " + pila.estaVacia());
Console.WriteLine("------------");



pila.añadir("objeto1");
pila.añadir("objeto2");
pila.añadir("objeto3");

Console.WriteLine("No se puede agregar un 4to elemento por el tamaño predefinido:" + pila.añadir("objeto4"));
Console.WriteLine("------------");

Console.WriteLine("Este es el array original: ");



for (int i = 0; i < pila.elementos.Length; i++)
{
    Console.WriteLine(pila.elementos[i]);
}
Console.WriteLine("------------");


Console.WriteLine("Ahora no está vacio " + pila.estaVacia());
Console.WriteLine("------------");


Console.WriteLine("Se extrae el primero: " + pila.extraer());

Console.WriteLine("------------");

Console.WriteLine("Se agrega otro objeto ");

pila.añadir("objeto4");

Console.WriteLine("------------");
Console.WriteLine("Este es el array actualizado: ");


for (int i = 0; i<pila.elementos.Length; i++)
{
    Console.WriteLine(pila.elementos[i]);
}

Console.WriteLine("------------");
Console.WriteLine("Este es el primer elemento: " + pila.primero());

Console.WriteLine();
Console.WriteLine();

Console.WriteLine("------------");

Console.WriteLine("Acá empieza el ejercicio de 'Colas'");

Cola cola = new Cola();

Console.WriteLine("Al principio esta vacia: " + cola.estaVacia());
Console.WriteLine();
Console.WriteLine("------------");
Console.WriteLine("Se añaden elementos a la lista");
Console.WriteLine();

cola.añadir("elemento1");
cola.añadir("elemento2");
cola.añadir("elemento3");


foreach (object i in cola.Elementos)
{
    Console.WriteLine(i);
}

Console.WriteLine("------------");
Console.WriteLine("Ahora no esta vacía: " + cola.estaVacia());
Console.WriteLine("------------");

Console.WriteLine("Se elimina el primer elemento: " + cola.extraer());

Console.WriteLine("------------");

Console.WriteLine("Lista actualizada");
Console.WriteLine();

foreach (object i in cola.Elementos)
{
    Console.WriteLine(i);
}

Console.WriteLine("------------");

Console.WriteLine("El primero es: " + cola.primero());
Console.WriteLine();


