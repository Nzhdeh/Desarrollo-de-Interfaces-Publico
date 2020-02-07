using JuegoParejasNzhdehBL.ListadosBL;
using JuegoParejasNzhdehET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace JuegoParejasNzhdehUI.ViewModels
{
    public class RankingVM
    {
        private ObservableCollection<ClsTopScore> listadoRanking;


        public RankingVM()
        {
            try
            {
                ClsListadoRankingBL rankingBL = new ClsListadoRankingBL();
                listadoRanking = new ObservableCollection<ClsTopScore>(rankingBL.obtenerPuntuacionesBL());
            }
            catch (Exception e)
            {
                var dlg = new MessageDialog("No hay conexión a internet. Inténtalo más tarde por favor");
                var res = dlg.ShowAsync();
            }

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
