using clase_27_8_BANCO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase_27_8_BANCO.Repositories.Contracts
{
    public interface ITipos_cuenta
    {
        public List<Tipos_cuenta> GetTipos();
        public Tipos_cuenta GetById(int id);
    }
}
