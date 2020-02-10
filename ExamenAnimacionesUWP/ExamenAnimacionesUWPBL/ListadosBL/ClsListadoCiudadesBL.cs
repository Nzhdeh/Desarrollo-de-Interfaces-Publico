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
    public class ClsListadoCiudadesBL
    {
        /// <summary>
        /// esta funcion sirve para obtener el listado de todas las ciudades de la DAL
        /// </summary>
        /// <returns>Listado de ciudades List<clsPersona></returns>
        public async Task<ObservableCollection<ClsCiudad>> listadoCiudadesBL()
        {
            ClsListadoCiudadesDAL listBBDD = new ClsListadoCiudadesDAL();
            //Task<ObservableCollection<ClsCiudad>> l = listBBDD.listadoCiudadesDAL();
            ObservableCollection<ClsCiudad> listado = await listBBDD.listadoCiudadesDAL();
            return listado;
        }

        /// <summary>
        /// obtiene el listado de predicciones de una ciudad
        /// </summary>
        /// <param name="id"></param>
        /// <returns>listado de pronosticos</returns>
        public async Task<ObservableCollection<ClsPrediccion>> listadoPrediccionPorCiudadDAL(int id)
        {
            ClsListadoCiudadesDAL listBBDD = new ClsListadoCiudadesDAL();
            ObservableCollection<ClsPrediccion> listado = await listBBDD.listadoPrediccionPorCiudadDAL(id);
            return listado;
        }
    }
}
