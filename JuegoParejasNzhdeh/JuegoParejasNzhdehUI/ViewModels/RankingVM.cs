using JuegoParejasNzhdehBL.ListadosBL;
using JuegoParejasNzhdehET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoParejasNzhdehUI.ViewModels
{
    public class RankingVM
    {
        private ObservableCollection<ClsTopScore> listadoRanking;


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
