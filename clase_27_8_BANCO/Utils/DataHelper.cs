using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase_27_8_BANCO.Utils
{
    public class DataHelper
    {
        private SqlConnection _connection;

        private static DataHelper _instance;

        private DataHelper()
        {
            _connection = new SqlConnection(Properties.Resources.CnnString);
        }

        public static DataHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }

        public DataTable ExecuteSp(string sp)
        {
            DataTable dt = new DataTable();

            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception)
            {
                dt = null;
                Console.WriteLine("error");
            }
            finally { 
                _connection.Close(); 
            }
            return dt;
        }
    }


}
