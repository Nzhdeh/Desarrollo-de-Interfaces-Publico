using _19_CRUDPersonas_DAL.Listados;
using _19_CRUDPersonas_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_CRUDPersonas_BL.Listados
{
    public class ClsListadoPersonasBL
    {
        public async Task<List<ClsPersona>> getListadoPersonasBL()
        {
            List<ClsPersona> lista;

            ClsListadoPersonasDAL listadoPersonasDAL = new ClsListadoPersonasDAL();

            lista = listadoPersonasDAL.ListadoCompletoPersonas();

            return lista;
        }
    }
}
