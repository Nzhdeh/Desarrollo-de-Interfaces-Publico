using CamellosDAL.ListadosDAL;
using CamellosET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamellosBL.ListadosBL
{
    public class ClsListadoProgresosBL
    {
        /// <summary>
        /// prototipo: public ObservableCollection<ClsParaListadoProgresos> ObtenerProgresosPorJugadorBL(int id)
        /// comentarios: sirve para obtener el listado de progresos de un jugador
        /// precondiciones: el idJugador tiene que ser correcto
        /// </summary>
        /// <param name="idJugador">entero </param>
        /// <returns>ObservableCollection<ClsParaListadoProgresos> progresos</returns>
        /// postcondiciones: asociado a nombre devuelve el listado de progresos de un jugador
        public ObservableCollection<ClsParaListadoProgresos> ObtenerProgresosPorJugadorBL(int id)
        {
            ObservableCollection<ClsParaListadoProgresos> progresos = new ObservableCollection<ClsParaListadoProgresos>();

            try
            {
                progresos = new ClsListadoProgresosDAL().ObtenerProgresosPorJugadorDAL(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return progresos;
        }
    }
}
