using CamellosET;
using CamellosUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CamellosUI.ViewModels
{
    public class ClsMenuVM
    {
        private DelegateCommand jugarCommand;
        private DelegateCommand salirCommand;
        private DelegateCommand cerrarSesionCommand;
        private DelegateCommand verProgresosCommand;
        private string nick;

        #region constructores
        public ClsMenuVM()
        {
            this.nick = "";
        }


        public ClsMenuVM(string nick)
        {
            if (nick != null)
                this.nick = nick;
        }
        #endregion

        #region propiedades publicas
        public string Nick
        {
            get
            {
                return nick;
            }
            set
            {
                this.nick = value;
            }
        }

        public DelegateCommand JugarCommand
        {
            get
            {
                this.jugarCommand = new DelegateCommand(jugar);
                return jugarCommand;
            }
            set
            {
                this.jugarCommand = value;
            }
        }

        public DelegateCommand SalirCommand
        {
            get
            {
                this.salirCommand = new DelegateCommand(mensajeSalida);
                return salirCommand;
            }
            set
            {
                this.salirCommand = value;
            }
        }



        public DelegateCommand CerrarSesionCommand
        {
            get
            {
                this.cerrarSesionCommand = new DelegateCommand(mensajeCerrarSesion);
                return cerrarSesionCommand;
            }
            set
            {
                this.cerrarSesionCommand = value;
            }
        }


        public DelegateCommand VerProgresosCommand
        {
            get
            {
                this.verProgresosCommand = new DelegateCommand(verProgresos);
                return verProgresosCommand;
            }
            set
            {
                this.verProgresosCommand = value;
            }
        }
        #endregion

        #region metodos privados
        /// <summary>
        /// sirve para acceder a la vista del juego
        /// </summary>
        private void jugar()
        {
            Frame FrameActual = (Frame)Window.Current.Content;
            FrameActual.Navigate(typeof(Juego), nick);
        }

        /// <summary>
        /// sirve para salir del juego directamente
        /// </summary>
        private void salir()
        {
            Application.Current.Exit();
        }

        /// <summary>
        /// sirve para ir a LogIn
        /// </summary>
        private void cerrarSesion()
        {
            Frame FrameActual = (Frame)Window.Current.Content;
            FrameActual.Navigate(typeof(LogIn));
        }

        private void verProgresos()
        {
            Frame FrameActual = (Frame)Window.Current.Content;
            FrameActual.Navigate(typeof(Progreso), this.nick);
        }

        /// <summary>
        /// sirve para controlar la salida del juego
        /// </summary>
        private async void mensajeSalida()
        {
            ContentDialog saliDialogo = new ContentDialog
            {
                Title = "Se cerrará la aplicación",
                PrimaryButtonText = "Salir",
                CloseButtonText = "Cancelar"
            };

            if (await saliDialogo.ShowAsync() == ContentDialogResult.Primary)
            {
                salir();
            }
        }

        /// <summary>
        /// sirve para controlar el cierre de la sesión
        /// </summary>
        private async void mensajeCerrarSesion()
        {
            ContentDialog saliDialogo = new ContentDialog
            {
                Title = "¿Quieres cerrar sesión?",
                PrimaryButtonText = "Cerrar",
                CloseButtonText = "Cancelar"
            };

            if (await saliDialogo.ShowAsync() == ContentDialogResult.Primary)
            {
                cerrarSesion();
            }
        }
        #endregion
    }
}
