// See https://aka.ms/new-console-template for more information
using clase_1;


Producto p = new Pack(2, 1, "Coca", 1700);
Producto s = new Suelto(1, 2, "Pepsi", 1500);

Producto[] productos = { p, s };


foreach (Producto o in productos)
{
    Console.WriteLine(o.CalcularPrecio());
}


