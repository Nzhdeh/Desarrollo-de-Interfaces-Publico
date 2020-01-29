using CRUDXamarin_DAL.ListadosDAL;
using CRUDXamarin_ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDXamarin_BL.ListadosBL
{
    public class ClsListadoPersonasBL
    {
        public async Task<List<ClsPersona>> getListadoPersonasBL()
        {
            List<ClsPersona> lista;

            ClsListadoPersonasDAL listadoPersonasDAL = new ClsListadoPersonasDAL();

            lista = await listadoPersonasDAL.ListadoCompletoPersonas();

            return lista;
        }
    }
}
