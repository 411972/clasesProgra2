using WebAPIEntityFramework.Data.Models;

namespace WebAPIEntityFramework.Data.Repositories
{
    public interface ILibroRepository
    {
        void Create(Libro libro);

        void Update(Libro libro);

        void Delete(int id);

        List<Libro> GetAll();

        Libro GetById(int id);


    }
}
