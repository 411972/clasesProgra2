// See https://aka.ms/new-console-template for more information

using clase_3_23_agosto_repository.Domain;
using clase_3_23_agosto_repository.Services;

ProductService  productService = new ProductService();

List<Product> lp = productService.GetProducts();

foreach (Product p in lp)
{
    Console.WriteLine(p);
}