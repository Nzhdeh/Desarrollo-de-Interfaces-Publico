using JuegoParejasNzhdehDAL.ListadosDAL;
using JuegoParejasNzhdehET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoParejasNzhdehBL.ListadosBL
{
    public class ClsListadoRankingBL
    {
        /// <summary>
        /// sirve para obtener el listado del ranking del juego
        /// </summary>
        /// <returns>Listado de Ranking</returns>
        public ObservableCollection<ClsTopScore> obtenerPuntuacionesBL()
        {
            ObservableCollection<ClsTopScore> scores = new ObservableCollection<ClsTopScore>();
            ClsListadoRanking listadoPuntuaciones = new ClsListadoRanking();

            scores = listadoPuntuaciones.obtenerRanking();
            return scores;
        }
    }
}
