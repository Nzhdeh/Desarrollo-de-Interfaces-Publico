using PreparandoExamen1Trimestre_DAL.Listados;
using PreparandoExamen1Trimestre_ENTITIES;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreparandoExamen1Trimestre_BL.Listados
{
    public class ClsListadoDeUsuariosBL
    {
        public ObservableCollection<ClsUsuario> ObtenerListadoUsuariosBL()
        {
            ObservableCollection<ClsUsuario> lista;

            ClsListadoDeUsuariosDAL listadoPersonasDAL = new ClsListadoDeUsuariosDAL();

            lista = listadoPersonasDAL.ObtenerListadoUsuariosDAL();

            return lista;
        }
    }
}
