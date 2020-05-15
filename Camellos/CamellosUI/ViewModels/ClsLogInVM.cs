using CamellosBL.ManejadorasBL;
using CamellosET;
using CamellosUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace CamellosUI.ViewModels
{
    public class ClsLogInVM : ClsVMBase
    {
        private string nickLogIn;
        private string contraseniaLogIn;
        private DelegateCommand entrarCommand;
        private string mensajeErrorNickOContraseniaIncorrectos;
        private bool progressRing;

        #region constructores
        public ClsLogInVM()
        {
            this.progressRing = false;
            this.mensajeErrorNickOContraseniaIncorrectos = "";
        }

        public ClsLogInVM(string mensajeErrorNickOContraseñaIncorrectos, bool isMensajeErrorVisible)
        {
            this.mensajeErrorNickOContraseniaIncorrectos = mensajeErrorNickOContraseñaIncorrectos;
        }
        #endregion

        #region propiedades publicas
        public bool ProgressRing
        {
            get
            {
                return this.progressRing;
            }
            set
            {
                this.progressRing = value;
            }
        }
        public string MensajeErrorNickOContraseniaIncorrectos
        {
            get
            {
                return this.mensajeErrorNickOContraseniaIncorrectos;
            }
            set
            {
                this.mensajeErrorNickOContraseniaIncorrectos = value;
            }
        }

        public string NickLogIn
        {
            get
            {
                return this.nickLogIn;
            }
            set
            {
                this.nickLogIn = value;

                if (this.nickLogIn != null)
                {
                    this.mensajeErrorNickOContraseniaIncorrectos = "";//para que desaparazca el mensaje de error cada vez que intenta poner un nick válido
                    NotifyPropertyChanged("MensajeErrorNickOContraseniaIncorrectos");
                }
            }
        }

        public string ContraseniaLogIn
        {
            get
            {
                return this.contraseniaLogIn;
            }
            set
            {
                this.contraseniaLogIn = value;
                if (this.contraseniaLogIn != null)
                {
                    this.mensajeErrorNickOContraseniaIncorrectos = "";//para que desaparazca el mensaje de error cada vez que intenta poner un contraseña válida
                    NotifyPropertyChanged("MensajeErrorNickOContraseniaIncorrectos");
                }
            }
        }

        public DelegateCommand EntrarCommand
        {
            get
            {
                this.entrarCommand = new DelegateCommand(entrar);
                return entrarCommand;
            }
            set
            {
                this.entrarCommand = value;
            }
        }
        #endregion

        #region metodos publicos
        /// <summary>
        /// sirve para que funcione con el botón enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Btn_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                EntrarCommand.Execute(null);//llamamos a la funcion sin parametro                
            }
        }
        #endregion

        #region metodos privados
        /// <summary>
        /// sirve para acceder al juego
        /// </summary>
        private void entrar()
        {
            bool correcto = false;
            try
            {
                this.progressRing = true;
                NotifyPropertyChanged("ProgressRing");
                correcto = new ClsManejadoraJugadorBL().ComprobarNickYContraseñaCorrectosBL(this.nickLogIn, this.contraseniaLogIn);
                if (correcto)
                {
                    this.progressRing = false;
                    NotifyPropertyChanged("ProgressRing");
                    acceder();
                }
                else
                {
                    this.progressRing = false;
                    NotifyPropertyChanged("ProgressRing");
                    mensajeErrorNickOContraseniaIncorrectos = "Nick o contraseña incorrectos";
                    NotifyPropertyChanged("MensajeErrorNickOContraseniaIncorrectos");
                }
            }
            catch (Exception)
            {
                //por si no hay conexion o la cadena esta mal puesta
                var dlg = new MessageDialog("Problemas de conexión. Inténtalo más tarde por favor");
                var res = dlg.ShowAsync();
            }
        }

        /// <summary>
        /// sirve para ir a la vista del Menu
        /// </summary>
        private void acceder()
        {
            Frame FrameActual = (Frame)Window.Current.Content;
            FrameActual.Navigate(typeof(Menu), this.nickLogIn);
        }
        #endregion
    }
}
