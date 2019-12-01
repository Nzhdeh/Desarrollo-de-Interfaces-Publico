using PreparandoExamen02_12_2019_DAL.Listado;
using PreparandoExamen02_12_2019_ENTITIES;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreparandoExamen02_12_2019_BL.Listado
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
