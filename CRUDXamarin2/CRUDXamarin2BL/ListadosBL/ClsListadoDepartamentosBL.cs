using CRUDXamarin2DAL.ListadosDAL;
using CRUDXamarin2ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDXamarin2BL.ListadosBL
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
