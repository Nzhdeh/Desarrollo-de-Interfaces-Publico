using CombateSuperheroesVillanosDAL.Conexion;
using CombateSuperheroesVillanosDAL.ListadosDAL;
using CombateSuperheroesVillanosET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombateSuperheroesVillanosBL.ListadosBL
{
    public class ClsListadoSuperheroesBL
    {
        /// <summary>
        /// prototipo: public ObservableCollection<ClsLuchador> ObtenerListadoLuchadoresBL()
        /// comentarios: sirve para obtener el listado de los todos los luchadores
        /// precondiciones: no hay
        /// </summary>
        /// <returns>ObservableCollection<ClsLuchador> luchadores</returns>
        /// postcondiciones: asociado a nombre devuelve el listado de todos los luchadores o un null si no hay Luchadores o SQLException si no hay conexion
        public ObservableCollection<ClsLuchador> ObtenerListadoLuchadoresBL()
        {
            ObservableCollection<ClsLuchador> luchadores = new ObservableCollection<ClsLuchador>();

            try
            {
                luchadores = new ClsListadoSuperheroesDAL().ObtenerListadoLuchadoresDAL();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return luchadores;
        }
    }
}
