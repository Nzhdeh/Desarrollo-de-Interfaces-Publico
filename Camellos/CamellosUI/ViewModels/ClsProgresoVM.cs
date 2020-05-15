using CamellosBL.ListadosBL;
using CamellosBL.ManejadorasBL;
using CamellosET;
using CamellosUI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CamellosUI.ViewModels
{
    public class ClsProgresoVM
    {
        private ObservableCollection<ClsParaListadoProgresos> listadoProgresosPorJugador;
        private string nick;
        private DelegateCommand menuAnteriorCommand;

        public ClsProgresoVM()
        {
            this.listadoProgresosPorJugador = new ObservableCollection<ClsParaListadoProgresos>();
        }

        public ClsProgresoVM(string nick)
        {
            try
            {
                if(nick != null)
                {
                    this.nick = nick;
                }
                
                int id = new ClsManejadoraJugadorBL().ObtenerIdJugadorPorNickDAL(this.nick);
                this.listadoProgresosPorJugador = new ClsListadoProgresosBL().ObtenerProgresosPorJugadorBL(id);

                if (this.listadoProgresosPorJugador.Count == 0)
                {
                    var dlg = new MessageDialog("No has hecho ningún progreso aún");
                    var res = dlg.ShowAsync();
                }
            }
            catch (SqlException)
            {
                var dlg = new MessageDialog("Problemas de conexión. Inténtalo más tarde por favor");
                var res = dlg.ShowAsync();
            }
        }

        public ClsProgresoVM(ObservableCollection<ClsParaListadoProgresos> listadoProgresosPorJugador)
        {
            this.listadoProgresosPorJugador = listadoProgresosPorJugador;
        }

        public DelegateCommand MenuAnteriorCommand
        {
            get
            {
                this.menuAnteriorCommand = new DelegateCommand(menuAnterior);
                return menuAnteriorCommand;
            }
            set
            {
                this.menuAnteriorCommand = value;
            }
        }

        public ObservableCollection<ClsParaListadoProgresos> ListadoProgresosPorJugador
        {
            get
            {
                return this.listadoProgresosPorJugador;
            }
            set
            {
                this.listadoProgresosPorJugador = value;
            }
        }

        public string Nick
        {
            get
            {
                return this.nick;
            }
            set
            {
                this.nick = value;
            }
        }

        /// <summary>
        /// sirve para ir al menu
        /// </summary>
        private void menuAnterior()
        {
            Frame FrameActual = (Frame)Window.Current.Content;
            FrameActual.Navigate(typeof(Menu),this.nick);
        }
    }
}
