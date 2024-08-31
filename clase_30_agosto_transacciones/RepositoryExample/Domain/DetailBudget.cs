using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryExample.Domain
{
    public class DetailBudget
    {
        public Product Product { get; set; }

        public int Amount { get; set; }

        public float Price { get; set; }

        public double Subtotal()
        {
            return Amount * Price;
        }
    }
}
