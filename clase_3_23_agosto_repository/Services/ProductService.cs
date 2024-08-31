using clase_3_23_agosto_repository.Data;
using clase_3_23_agosto_repository.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase_3_23_agosto_repository.Services
{
    public class ProductService
    {
        private IProductoRepository _repository;
        public ProductService()
        {
            _repository = new ProductoRepositoryADO();
        }

        public List<Product> GetProducts()
        {
            return _repository.GetAll();
        }


    }
}
