using TurnoApi.Models;

namespace TurnoApi.Repositorios
{
    public interface ITurnoRepository
    {
        Task<List<TTurno>> GetAll();

        Task<List<TTurno>> GetCancelados(int dias);
        Task<bool> Save(TTurno turno);
        Task<bool> Update(TTurno turno, int id);
        Task<bool> Delete(int id,string motivo);
    }
}
