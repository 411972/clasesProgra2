using RepositoryExample.Data;
using RepositoryExample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryExample.Services
{
    public class BudgetManager
    {
        private IBudgetRepository _repository;

        public BudgetManager()
        {
            _repository = new BudgetRepository();
        }

        public bool SaveBudget(Budget budget)
        {
            return _repository.Save(budget);
        }
    }
}
