
using RepositoryExample.Data;
using RepositoryExample.Domain;
using RepositoryExample.Services;

ProductManager manager = new ProductManager();
BudgetManager budgetManager = new BudgetManager();
//Create new product:
//var oProduct = new Product()
//{
//    Nombre = "PRODUCTO DE PRUEBA",
//    Stock = 2000,
//    Activo = true
//};
//if (manager.SaveProduct(oProduct))
//    Console.WriteLine("PRODUCTO CREADO EXISTOSAMENTE!");

//List all product of store:
//List<Product> lst = manager.GetProducts();
//if(lst.Count == 0)
//{
//    Console.WriteLine("Sin productos en la base de datos");

//}
//else
//{
//    foreach(var oProducto in lst)
//    {
//        Console.WriteLine(oProducto);
//    }
//}

////Delete product cod = 1:
//if (manager.DeleteProduct(1))
//    Console.WriteLine("PRODUCTO ACTUALIZADO CON DATOS DE BAJA!");

var oProduct = manager.GetProductByCodigo(1);

var oBudget = new Budget();

var oDetail1 = new DetailBudget();

var oDetail2 = new DetailBudget();

oDetail1.Product = oProduct;
oDetail1.Amount = 2;
oDetail1.Price = 2000;

oDetail2.Product = oProduct;
oDetail2.Amount = 3;
oDetail2.Price = 2500;

oBudget.AddDetail(oDetail1);
oBudget.AddDetail(oDetail2);
oBudget.Expiration = 5;
oBudget.Client = "Franco Catania";

if (budgetManager.SaveBudget(oBudget))
{
    Console.WriteLine("Budget creado");
}
else
{
    Console.WriteLine("error");
}