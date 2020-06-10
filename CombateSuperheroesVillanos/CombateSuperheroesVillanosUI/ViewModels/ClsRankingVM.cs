using CombateSuperheroesVillanosBL.ListadosBL;
using CombateSuperheroesVillanosUI.DTO;
using CombateSuperheroesVillanosUI.Utilidades;
using CombateSuperheroesVillanosUI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CombateSuperheroesVillanosUI.ViewModels
{
    public class ClsRankingVM
    {
        private ObservableCollection<ClsRankingDTO> listadoRanking;
        //private DelegateCommand salirCommand;

        public ClsRankingVM()
        {
            try
            {
                this.listadoRanking = new ClsListadoRankingBL().ObtenerListadoRankingBL();
                if(this.listadoRanking.Count == 0)
                {
                    var dlg = new MessageDialog("No hay ningun dato en la base de datos");
                    var res = dlg.ShowAsync();
                    atras();
                }
            }catch(Exception)
            {
                var dlg = new MessageDialog("Problemas de conexión. Inténtalo más tarde por favor");
                var res = dlg.ShowAsync();
            }
        }

        public ClsRankingVM(ObservableCollection<ClsRankingDTO> listadoRanking/*, DelegateCommand salirCommand*/)
        {
            this.listadoRanking = listadoRanking;
            //this.salirCommand = salirCommand;
        }

        public ObservableCollection<ClsRankingDTO> ListadoRanking
        {
            get
            {
                return this.listadoRanking;
            }
            set
            {
                this.listadoRanking = value;
            }
        }

        //public DelegateCommand SalirCommand
        //{
        //    get
        //    {
        //        salirCommand = new DelegateCommand(mensajeSalida);
        //        return salirCommand;
        //    }
        //    set
        //    {
        //        salirCommand = value;
        //    }
        //}

        #region metodos privados
        /// <summary>
        /// sirve para controlar la salida del juego
        /// </summary>
        //private async void mensajeSalida()
        //{
        //    ContentDialog saliDialogo = new ContentDialog
        //    {
        //        Title = "¿Quieres salir?",
        //        PrimaryButtonText = "Salir",
        //        CloseButtonText = "Cancelar"
        //    };

        //    if (await saliDialogo.ShowAsync() == ContentDialogResult.Primary)
        //    {
        //        atras();
        //    }
        //}

        /// <summary>
        /// sirve para ir a la vista principal
        /// </summary>
        private void atras()
        {
            Frame FrameActual = (Frame)Window.Current.Content;
            FrameActual.Navigate(typeof(Hamburguesa));
        }

        #endregion
    }
}
