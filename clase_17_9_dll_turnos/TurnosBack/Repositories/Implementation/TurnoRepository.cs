using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnosBack.Entities;
using TurnosBack.Repositories.Contracts;
using TurnosBack.Utils;

namespace TurnosBack.Repositories.Implementation
{
    public class TurnoRepository : ITurnoRepository
    {
        public int ContarTurnos(string fecha, string hora)
        {
            throw new NotImplementedException();
        }

        public bool InsertarMaestroDetalle(Turno turno)
        {
            SqlTransaction t = null;
            bool result = false;
            int idTurno;
            List<SqlParameter> parameters = new List<SqlParameter>();

            try
            {
                t = DataHelper.GetInstance().BeginTransaction();
                SqlParameter oPFecha = new SqlParameter("@fecha", turno.Fecha);
                SqlParameter oPHora = new SqlParameter("@hora", turno.Hora);
                SqlParameter oPCliente = new SqlParameter("@cliente", turno.Cliente);

                parameters.Add(oPFecha);
                parameters.Add(oPHora);
                parameters.Add(oPCliente);

                idTurno = DataHelper.GetInstance().ExecuteSPPostOutput("SP_INSERTAR_MAESTRO", t, parameters);

                SqlParameter idTurnoParameter = new SqlParameter("@id_turno", idTurno);
                foreach(DetalleTurno dt in turno.Detalles)
                {
                    List<SqlParameter> detallesParams = new List<SqlParameter>();
                    SqlParameter servicioParam = new SqlParameter("@id_servicio", dt.ServicioId);
                    SqlParameter observacionParam = new SqlParameter("@observaciones", dt.Observacion);

                    detallesParams.Add(idTurnoParameter);
                    detallesParams.Add(servicioParam);
                    detallesParams.Add(observacionParam);

                    DataHelper.GetInstance().ExecuteSPPost("SP_INSERTAR_DETALLES", t, detallesParams);

                }

                DataHelper.GetInstance().CommitTransaction(t);

                result = true;


            }
            catch (Exception exc)
            {
                DataHelper.GetInstance().RollbackTransaction(t);
                throw exc;
            }

            return result;


        }

        public List<Servicio> ObtenerServicios()
        {
            throw new NotImplementedException();
        }
    }
}
