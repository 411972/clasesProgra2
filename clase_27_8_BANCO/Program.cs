
using clase_27_8_BANCO.Entities;
using clase_27_8_BANCO.Services;

ClientesService clienteService= new ClientesService();

List<Cliente> lp = clienteService.GetClientes();

foreach (Cliente cl in lp)
{
    Console.WriteLine(cl);
}