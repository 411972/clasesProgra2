using clase_27_8_BANCO.Entities;
using clase_27_8_BANCO.Repositories.Contracts;
using clase_27_8_BANCO.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase_27_8_BANCO.Repositories.Implementations
{
    public class Tipos_cuentaRepository : ITipos_cuenta
    {
        public Tipos_cuenta GetById(int id)
        {
            Tipos_cuenta tp = new Tipos_cuenta();
            DataHelper.GetInstance().ExecuteSp("SP_OBTENER_CUENTA");
            return tp; //no implementado aún
        }

        public List<Tipos_cuenta> GetTipos()
        {
            List<Tipos_cuenta> lst = new List<Tipos_cuenta>();
            return lst;
        }
    }
}
