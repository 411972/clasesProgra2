using clase_3_23_agosto_repository.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase_3_23_agosto_repository.Data
{
    public class ProductoRepositoryADO : IProductoRepository
    {
        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            //conectar bd
            //traer registros
            var dt = DataHelper.GetInstance().ExecuteSp("SP_Recuperar_Productos");
            
            foreach(DataRow row in dt.Rows)
            {
                //mapear
                Product p = new Product();
                p.Codigo = (int)row["codigo"];
                p.Nombre = row["n_producto"].ToString();
                p.Precio = (double)row["precio"];
                p.Stock = (int)row["stock"];
                p.Activo = (bool)row["esta_activo"];
                products.Add(p);
            }
            
            //desconectar bd

            return products;

        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveProduct(Product oProduct)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
