using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Utils
{
    public class DataHelper
    {
        private static DataHelper _instancia;
        private static SqlConnection _connection;

        private DataHelper()
        {
            _connection = new SqlConnection("Data Source=DESKTOP-RCC7Q44\\SQLEXPRESS;Initial Catalog=BancoDb;Integrated Security=True;");
        }

        public static DataHelper GetInstance()
        {
            if (_instancia == null)
                _instancia = new DataHelper();

            return _instancia;
        }

        public SqlConnection OpenConnection()
        {
            if(_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            return _connection;
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public DataTable ExecuteSPQuery(string sp, List<ParameterSQL>? parametros)
        {
            DataTable t = new DataTable();
            SqlCommand cmd = null;

            try
            {
                _connection.Open();
                cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var param in parametros)
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                }

                t.Load(cmd.ExecuteReader());
            }
            catch (SqlException)
            {
                t = null;
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

            return t;
        }


        public int ExecuteSPDML(string sp, List<ParameterSQL>? parametros)
        {
            int rows;

            try
            {

                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (var param in parametros)
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                }


                rows = cmd.ExecuteNonQuery();
            }
            catch (SqlException exc)
            {
                rows = 0;
                throw exc;
            }


            return rows;
        }

        public int ExecuteSPDML(string sp, List<ParameterSQL>? parametros, SqlTransaction t)
        {
            int rows;
            
            try
            {
             
                var cmd = new SqlCommand(sp, _connection, t);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (var param in parametros)
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                }


                rows = cmd.ExecuteNonQuery();
            }
            catch (SqlException exc)
            {
                rows = 0;
                throw exc;
            }


            return rows;
        }


    }
}
