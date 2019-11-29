using _19_CRUDPersonas_DAL.Listados;
using _19_CRUDPersonas_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_CRUDPersonas_BL.Listados
{
    class ClsListadoDepartamentosBL
    {
        public List<ClsDepartamento> getListadoDepartamentosBL()
        {
            List<ClsDepartamento> lista;

            ClsListadoDepartamentosDAL listadoDepartamentosDAL = new ClsListadoDepartamentosDAL();

            lista = listadoDepartamentosDAL.getListadoDepartamentosDAL();

            return lista;

        }
    }
}
