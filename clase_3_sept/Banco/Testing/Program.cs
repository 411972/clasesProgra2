// Crear instancia del repositorio
using Banco.Entities;
using Banco.Repositories.Contracts;
using Banco.Repositories.Implementations;
using Banco.Services;

BancoManager serviceManager = new BancoManager();

//Prueba 1: Obtener todos los tipos de cuentas
Console.WriteLine("Tipos de Cuentas Disponibles:");
var tiposDeCuenta = serviceManager.GetAllTiposCuentas();



// se instancia cliente nuevo
Cliente nuevoCliente = new Cliente();

nuevoCliente.Nombre = "Franco";
nuevoCliente.Apellido = "Catania";
nuevoCliente.Dni = "22222222";

// Crear una nueva cuenta
var nuevaCuenta = new Cuenta
{
    Cbu = "42159702",
    Saldo = 7200m,
    TipoCuenta = tiposDeCuenta[0],
    UltimoMovimiento = DateTime.Now
};

var nuevaCuenta2 = new Cuenta
{
    Cbu = "1992835",
    Saldo = 13050m,
    TipoCuenta = tiposDeCuenta[1],
    UltimoMovimiento = DateTime.Now
};

// se agregan las cuentas
nuevoCliente.addCuenta(nuevaCuenta);
nuevoCliente.addCuenta(nuevaCuenta2);


if (serviceManager.CreateClient(nuevoCliente))
{
    Console.WriteLine("Cliente creado!");
    Console.WriteLine("Cuentas agregadas: ");
    foreach (Cuenta c in nuevoCliente.Cuentas)
    {
        Console.WriteLine("CBU: " + c.Cbu);
        Console.WriteLine("Saldo: " + c.Saldo);
        Console.WriteLine("Tipo Cuenta: " + c.TipoCuenta.Nombre);
    }
}



