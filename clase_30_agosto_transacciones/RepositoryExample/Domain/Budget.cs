using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryExample.Domain
{
    public class Budget
    {
        public int Id { get; set; }
        public string Client { get; set; }

        public DateTime Date { get; set; }

        public int Expiration { get; set; }

        public List<DetailBudget> DetailsBudget { get; set; }

        public Budget()
        {
            DetailsBudget = new List<DetailBudget>();
        }

        public void AddDetail(DetailBudget detail)
        {
            DetailsBudget.Add(detail);
        }

        public void DeleteDetailByIndex(int index) { 
            DetailsBudget.RemoveAt(index);
        }

        public void DeleteDetail(DetailBudget d)
        {
            DetailsBudget.Remove(d);
        }

        public double Total()
        {
            double total = 0;
            foreach(DetailBudget detail in DetailsBudget)
            {
                total += detail.Subtotal();
            }
            return total;
        }
    }
}
