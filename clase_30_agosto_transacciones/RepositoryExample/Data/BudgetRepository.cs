using RepositoryExample.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryExample.Data
{
    public class BudgetRepository : IBudgetRepository
    {
        public List<Budget> GetAll()
        {
            throw new NotImplementedException();
        }

        public Budget GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Budget budget)
        {
            bool result = true;
            SqlConnection cnn = null;
            SqlTransaction t = null;
            
            try
            {
                cnn = DataHelper.GetInstance().GetConnection(); //se podria usar el GetInstance pero ahora es un ejemplo para hacer todo aca, no se usa el singleton
                cnn.Open();
                t = cnn.BeginTransaction();
                var cmd = new SqlCommand("SP_INSERTAR_MAESTRO", cnn, t); // se crea command
                cmd.CommandType = CommandType.StoredProcedure; // se setea que es un sp
                cmd.Parameters.AddWithValue("@cliente", budget.Client); //se setean parametros
                cmd.Parameters.AddWithValue("@vigencia", budget.Expiration);

                SqlParameter param = new SqlParameter("@id", SqlDbType.Int); //se crea el param que va a guardar el parametro que retorna el SP
                param.Direction = ParameterDirection.Output; //definir explicitamente que sea de salida
                cmd.Parameters.Add(param); //se agrega al cmd

                cmd.ExecuteNonQuery(); // se ejecuta cmd

                int idBudget = (int)param.Value; // se obtiene el valor del parametro que retorna el SP
                int idDetail = 1;
                foreach (DetailBudget detail in budget.DetailsBudget) // por cada detalle se invoca el SP, en el foreache se agregan los params a un nuevo cmd
                {
                    var cmdDetail = new SqlCommand("SP_INSERTAR_DETALLE", cnn, t);
                    cmdDetail.CommandType = CommandType.StoredProcedure;
                    cmdDetail.Parameters.AddWithValue("@presupuesto", idBudget);
                    cmdDetail.Parameters.AddWithValue("@id_detalle", idDetail);
                    cmdDetail.Parameters.AddWithValue("@producto", detail.Product.Codigo);
                    cmdDetail.Parameters.AddWithValue("@cantidad", detail.Amount);
                    cmdDetail.Parameters.AddWithValue("@precio", detail.Price);
                    cmdDetail.ExecuteNonQuery();

                    idDetail++;
                }

                t.Commit();
                
            }
            catch (Exception)
            {
                if (t != null)
                {
                    t.Rollback();
                }
                result = false;
            }
            finally {
                if (cnn != null && cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }

            }

            return result;
        }
    }
}
