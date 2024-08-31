using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase_3_23_agosto_repository.Data
{
    public class DataHelper
    {

        private static SqlConnection _connection;

        private static DataHelper _instance;
        private DataHelper()
        {
            _connection = new SqlConnection(Properties.Resources.StrConnection);
        }

        public static DataHelper GetInstance()
        {
            if(_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }

        public  DataTable ExecuteSp(string sp)
        {

            DataTable dt = new DataTable();

            try
            {
                _connection.Open(); //abro conection
                var cmd = new SqlCommand(sp, _connection); //creo el comand
                cmd.CommandType = CommandType.StoredProcedure; // configuro el tipo a SP
                dt.Load(cmd.ExecuteReader()); // Cargar la datatable
                _connection.Close(); //cierro conection
            }
            catch (SqlException)
            {

                dt = null;
                Console.WriteLine("error");
            }

            return dt;

        }
    }
}
