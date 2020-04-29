using CuestionarioCoronavirusDAL.ListadosDAL;
using CuestionarioCoronavirusET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace CuestionarioCoronavirusBL.ListadosBL
{
    public class ClsListadoPreguntasBL
    {
        /// <summary>
        /// sirve para obtener el listado de todas las preguntas de la base de datos
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<ClsPregunta> ListadoPreguntasBL()
        {
            ObservableCollection<ClsPregunta> lista = new ObservableCollection<ClsPregunta>();
            try
            {
                ClsListadoPreguntasDAL l = new ClsListadoPreguntasDAL();
                lista = l.ListadoCompletoPreguntasDAL();
            }
            catch (SqlException exSql)
            {
                var dlg = new MessageDialog("Hubo un problema. Inténtalo más tarde por favor");
                var res = dlg.ShowAsync();
            }
            return lista;
        }        
    }
}
