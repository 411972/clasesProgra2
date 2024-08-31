using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clase_3_23_agosto_repository.Domain;

namespace clase_3_23_agosto_repository.Data
{
    public interface IProductoRepository
    {
        List<Product> GetAll();

        Product GetById(int id);

        bool SaveProduct(Product oProduct);

        bool Delete(int id);
    }
}
