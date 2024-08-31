namespace clase_3_23_agosto_repository.Domain
{
    public class Product
    {
        public int Codigo { get; set; }

        public string Nombre { get; set; }

        public double Precio { get; set; }

        public int Stock { get; set; }

        public bool Activo { get; set; }
        public Product()
        {
            
        }

        public override string ToString()
        {
            return Nombre;
        }

    }
}