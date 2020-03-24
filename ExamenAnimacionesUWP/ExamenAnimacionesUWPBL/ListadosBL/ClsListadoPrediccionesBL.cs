using ExamenAnimacionesUWPDAL.ListadosDAL;
using ExamenAnimacionesUWPET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenAnimacionesUWPBL.ListadosBL
{
    public class ClsListadoPrediccionesBL
    {
        /// <summary>
        /// obtiene el listado de predicciones de una ciudad
        /// </summary>
        /// <param name="id"></param>
        /// <returns>listado de pronosticos</returns>
        public async Task<ObservableCollection<ClsPrediccion>> listadoPrediccionPorCiudadDAL(int id)
        {

            ClsListadoPrediccionesDAL listBBDD = null;
            ObservableCollection<ClsPrediccion> listado = null;
            try
            {
                listBBDD = new ClsListadoPrediccionesDAL();
                listado = await listBBDD.listadoPrediccionPorCiudadDAL(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listado;
        }
    }
}
