using clase_27_8_BANCO.Entities;
using clase_27_8_BANCO.Repositories.Contracts;
using clase_27_8_BANCO.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase_27_8_BANCO.Repositories.Implementations
{
    public class ClienteRepository : IClienteRepository
    {
        public List<Cliente> GetAll()
        {
            List<Cliente> clientes = new List<Cliente>();

            var dt = DataHelper.GetInstance().ExecuteSp("SP_OBTENER_CLIENTES");

            foreach (DataRow row in dt.Rows)
            {
                Cliente cliente = new Cliente();
                cliente.ID_CLIENTE = (int)row["ID_CLIENTE"];
                cliente.NOMBRE = (string)row["NOMBRE"];
                cliente.APELLIDO = (string)row["APELLIDO"];
                cliente.DNI = (int)row["DNI"];
                //List<Cuentas> lst = new List<Cuentas>();
                clientes.Add(cliente);
            }
            return clientes;
        }
    }
}
