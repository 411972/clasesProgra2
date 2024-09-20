using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using TurnosBack.Entities;

namespace TurnosBack.Utils
{
    public class DataHelper
    {
        private  SqlConnection _connection;

        private static DataHelper instance;

        private DataHelper()
        {
            _connection = new SqlConnection("Data Source=DESKTOP-RCC7Q44\\SQLEXPRESS;Initial Catalog=db_turnos;Integrated Security=True;");

        }

        public static DataHelper GetInstance()
        {
            if(instance == null)
            {
                instance = new DataHelper();
            }
            return instance;
        }

        public SqlConnection OpenConnection()
        {
            if(_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            
            return _connection;
        }

        public SqlConnection CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }

            return _connection;
        }

        public SqlTransaction BeginTransaction()
        {
            return OpenConnection().BeginTransaction();
        }

        public void CommitTransaction(SqlTransaction transaction)
        {
            transaction.Commit();
        }

        public void RollbackTransaction(SqlTransaction transaction)
        {
            transaction.Rollback();
        }

        public int ExecuteSPPostOutput(string sp, SqlTransaction t, List<SqlParameter> lstP)
        {
            int IdTurno;
            SqlCommand cmd = new SqlCommand(sp, _connection, t);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                foreach(SqlParameter p in lstP)
                {
                    cmd.Parameters.AddWithValue(p.ParameterName, p.Value);
                }

                SqlParameter pOutput = new SqlParameter("@id", SqlDbType.Int);
                pOutput.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(pOutput);

                cmd.ExecuteNonQuery();

                IdTurno = (int)pOutput.Value;

                
            }
            catch (Exception exc)
            {
                throw exc;
            }

            return IdTurno;
        }

        public bool ExecuteSPPost(string sp, SqlTransaction t, List<SqlParameter> lstP)
        {
            bool result = false;
            int rows = 0;
            SqlCommand cmd = new SqlCommand(sp, _connection, t);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                foreach (SqlParameter p in lstP)
                {
                    cmd.Parameters.AddWithValue(p.ParameterName, p.Value);
                }
                
                rows = cmd.ExecuteNonQuery();


            }
            catch (Exception exc)
            {
                throw exc;
            }

            if (rows > 0)
            {
                result = true;
            }
            return result;
        }

    }
}
