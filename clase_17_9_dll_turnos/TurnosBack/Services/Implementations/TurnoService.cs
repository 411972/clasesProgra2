using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnosBack.Entities;
using TurnosBack.Repositories.Implementation;
using TurnosBack.Repositories.Contracts;
using TurnosBack.Services.Contracts;

namespace TurnosBack.Services.Implementations
{
    public class TurnoService : ITurnoService
    {
        private readonly ITurnoRepository _turnoService;

        public TurnoService()
        {
            _turnoService = new TurnoRepository();
        }
        public int ContarTurnos(string fecha, string hora)
        {
            throw new NotImplementedException();
        }

        public bool InsertarMaestroDetalle(Turno turno)
        {
           return _turnoService.InsertarMaestroDetalle(turno);
        }

        public List<Servicio> ObtenerServicios()
        {
            throw new NotImplementedException();
        }
    }
}
