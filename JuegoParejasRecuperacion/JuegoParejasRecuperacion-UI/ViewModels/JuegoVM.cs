using JuegoParejasRecuperacion_ET;
using JuegoParejasRecuperacion_UI.Utilidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace JuegoParejasRecuperacion_UI.ViewModels
{
    public class JuegoVM : ClsVMBase
    {

        #region atributos privados
        private ObservableCollection<ClsCarta> listadoCartasAleatorias;
        private ClsCarta cartaSeleccionada;
        private ClsCarta carta1;
        private ClsCarta carta2;
        private int parejasEncontradas=0;
        private DelegateCommand volverMenuPrincipal;

        private DispatcherTimer tiempo;
        private string temporizador;
        private int time = 59;

        private string nickJugador;
        #endregion

       
        #region constructores
        public JuegoVM()
        {
            
            this.tiempo = new DispatcherTimer();
            this.tiempo.Interval = new TimeSpan(0, 0, 1);
            this.tiempo.Tick += Timer_Tik;
            this.Temporizador = "00:00:59";

            ClsObtenerListadoCartasAleatorias lista = new ClsObtenerListadoCartasAleatorias();
            listadoCartasAleatorias = lista.obtenerListadoCartasAleatorias();
        }

        #endregion

        #region temporizador
        private void Timer_Tik(object sender, object e)
        {
            if (time > 0)
            {

                if (time <= 10)
                {
                    time--;
                    Temporizador = string.Format("00:0{0}:0{1}", time / 60, time % 60);
                    NotifyPropertyChanged("Temporizador");
                }
                else
                {
                    time--;
                    Temporizador = string.Format("00:0{0}:{1}", time / 60, time % 60);
                    NotifyPropertyChanged("Temporizador");
                }
            }
        }
        #endregion temporizador

        #region propiedades publicas
        public ObservableCollection<ClsCarta> ListadoCartasAleatorias
        {
            get { return this.listadoCartasAleatorias; }
            set { this.listadoCartasAleatorias = value; }
        }

        public ClsCarta CartaSeleccionada
        {
            get { return this.cartaSeleccionada; }
            set
            {
                this.cartaSeleccionada = value;
                this.comprobarJugada();
            }
        }

        public DelegateCommand VolverMenuPrincipal
        {
            get { return this.volverMenuPrincipal; }
            set { this.volverMenuPrincipal = value; }
        }

        public string Temporizador
        {
            get;
            set;
        }
        #endregion

        #region metodos
        /// <summary>
        /// este metodo sirve para cambiar el estado del atributo descubierta de la cartaseleccionada
        /// y comprobar si es la primera de las dos, si es asi no compruebo si estáa su pareja y si es la seguinda ,
        /// comprobar si son parejas mientras bloquear el resto de las cartas para que no se les pueda dar vueltas ,
        /// si lo son mantenerlas volteadas y bloquear estas dos para que no se les vuelvan a dar clic y desbloquear 
        /// el resto de las cartas para seguir jugando
        /// 
        /// </summary>
        private async void comprobarJugada()
        {
            cartaSeleccionada.Descubierta = true;
            //comprobar si es la primera o la segunda
            if (carta1==null)
            {
                carta1 = cartaSeleccionada;

                carta1.Descubierta = true;
            }
            else if (carta2 == null)
            {
                carta2 = cartaSeleccionada;
                carta2.Descubierta = true;
            }

            //comprobamos si son iguales
            if(carta1!=null && carta2!=null)
            {
                if(carta2.IdCarta==carta1.IdCarta)
                {
                    parejasEncontradas++;
                    carta1=null;
                    carta2=null;
                }
                else
                {
                    //para que esperes un poco antes de dar la vuelta
                    Task task = Task.Delay(500);
                    await task.AsAsyncAction();
                    carta1.Descubierta = false;
                    carta2.Descubierta = false;
                    carta1 = null;
                    carta2 = null;
                }
            }

            if (parejasEncontradas == 6)
            {
                string res=await MensajeGanador();
            }
        }

        /// <summary>
        /// para mostrar un dialogo que ya ha acabado la partida o que ha ganado
        /// para que introduzca el nombre
        /// </summary>
        /// <returns></returns>
        public async Task<string> MensajeGanador()
        {
            //    ContentDialog mensaje = new ContentDialog();
            //    Frame frame = Window.Current.Content as Frame;

            //    mensaje.Title = "Termina";
            //    mensaje.Content = "Has Terminado";
            //    mensaje.PrimaryButtonText = "Por fin";

            //    ContentDialogResult finale = await mensaje.ShowAsync();

            string resultado;
            TextBox inputTextBox = new TextBox();
            inputTextBox.AcceptsReturn = false;
            inputTextBox.Height = 32;
            ContentDialog dialog = new ContentDialog();
            dialog.Content = inputTextBox;
            dialog.Title = "Has terminado!!! Introduce tu alias";
            dialog.IsSecondaryButtonEnabled = true;
            dialog.PrimaryButtonText = "Ok";
            dialog.SecondaryButtonText = "Cancel";
            if (await dialog.ShowAsync() == ContentDialogResult.Primary)
                resultado = inputTextBox.Text;
            else
                resultado = "";

            return resultado;

        }
        #endregion

    }
}
