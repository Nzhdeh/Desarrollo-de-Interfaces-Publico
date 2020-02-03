using JuegoParejasRecuperacion_BL.ListadosBL;
using JuegoParejasRecuperacion_ET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoParejasRecuperacion_UI.ViewModels
{
    public class RankingVM
    {
        private ObservableCollection<ClsTopScore> listadoRanking;
        private DelegateCommand atras;//para ir al menu principal


        public RankingVM()
        {
            ClsListadoRankingBL rankingBL = new ClsListadoRankingBL();
            listadoRanking = new ObservableCollection<ClsTopScore>(rankingBL.obtenerPuntuacionesBL());
        }

        public ObservableCollection<ClsTopScore> ListadoRanking
        {
            get
            {
                return listadoRanking;
            }
            set
            {
                listadoRanking = value;
            }
        }
    }
}
