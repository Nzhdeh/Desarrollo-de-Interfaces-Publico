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
            ClsListadoCiudadesDAL listBBDD = null;
            ObservableCollection<ClsCiudad> listado = null;
            try
            {
                listBBDD = new ClsListadoCiudadesDAL();
                listado = await listBBDD.listadoCiudadesDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listado;
        }
    }
}
