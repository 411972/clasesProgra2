using Banco.Entities;
using Banco.Repositories.Contracts;
using Banco.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Repositories.Implementations
{
    public class ClienteRepository : IClienteRepository
    {
        public List<Cliente> GetAll()
        {
            var clientes = new List<Cliente>();
            DataTable table = DataHelper
                .GetInstance()
                .ExecuteSPQuery("OBTENER_CLIENTES", null);

            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    Cliente cliente = new Cliente
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Nombre = row["Nombre"].ToString(),
                        Apellido = row["Apellido"].ToString(),
                        Dni = row["Dni"].ToString()
                    };
                    clientes.Add(cliente);
                }
            }

            return clientes;
        }

        public bool Add(Cliente cliente)
        {
            var parametros = new List<ParameterSQL>
            {
                new ParameterSQL("@Nombre", cliente.Nombre),
                new ParameterSQL("@Apellido", cliente.Apellido),
                new ParameterSQL("@Dni", cliente.Dni)
            };

            SqlTransaction t = null;
            int filasAfectadas = 0;
            int idCliente;
            SqlCommand cmd = null;
            SqlConnection cnn = null;
            try
            {
                cnn = DataHelper.GetInstance().OpenConnection();
                t = cnn.BeginTransaction();

                cmd = new SqlCommand("CREAR_CLIENTE", cnn, t);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // PARAMETROS ENTRADA
                foreach(ParameterSQL p in parametros)
                {
                    cmd.Parameters.AddWithValue(p.Name, p.Value);
                }
                // PARAMETROS SALIDA
                SqlParameter paramOut = new SqlParameter("@ID_CLIENTE", SqlDbType.Int);
                //sqlParameter puede recibir la direccion. Es una sobrecarga
                paramOut.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(paramOut);

                cmd.ExecuteNonQuery();

                idCliente = (int)paramOut.Value;
                cliente.Id = idCliente;

                foreach (Cuenta c in cliente.Cuentas)
                {
                    c.ClienteId = idCliente;
                    List<ParameterSQL> pC = new List<ParameterSQL>();
                    pC.Add(new ParameterSQL("@CBU", c.Cbu));
                    pC.Add(new ParameterSQL("@SALDO", c.Saldo));
                    pC.Add(new ParameterSQL("@ULTIMO_MOVIMIENTO", c.UltimoMovimiento));
                    pC.Add(new ParameterSQL("@TIPO_CUENTA_ID", c.TipoCuenta.Id));
                    pC.Add(new ParameterSQL("@CLIENTE_ID", c.ClienteId));
                    filasAfectadas = DataHelper.GetInstance().ExecuteSPDML("CREAR_CUENTA", pC, t);
                }

                t.Commit();

            }
            catch (Exception exc)
            {
                t.Rollback();
                throw exc;
            }
            finally
            {

                DataHelper.GetInstance().CloseConnection();
            }


            return filasAfectadas > 0;
        }


        public bool Update(int idCliente, )
        {
            bool result = true;

            return result;
        }
    }
}
