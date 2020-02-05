using JuegoParejasNzhdehBL.ManejadorasBL;
using JuegoParejasNzhdehET;
using JuegoParejasNzhdehUI.Utilidades;
using JuegoParejasNzhdehUI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace JuegoParejasNzhdehUI.ViewModels
{
    public class JuegoVM : ClsVMBase
    {

        #region atributos privados
        private ObservableCollection<ClsCarta> listadoCartasAleatorias;
        private ClsCarta cartaSeleccionada;
        private ClsCarta carta1;
        private ClsCarta carta2;
        private int parejasEncontradas=0;
        private DelegateCommand updateCommand;
        private bool isPartidaActiva;

        private DispatcherTimer tiempo;
        private string temporizador;
        private int time = 59;

        private string nickJugador;
        #endregion

       
        #region constructores
        public JuegoVM()
        {
            this.isPartidaActiva = true;
            this.tiempo = new DispatcherTimer();
            this.tiempo.Interval = new TimeSpan(0, 0, 1);
            this.tiempo.Tick += Timer_Tik;
            this.tiempo.Start();
            this.Temporizador = "00:00:59";

            ClsObtenerListadoCartasAleatorias lista = new ClsObtenerListadoCartasAleatorias();
            listadoCartasAleatorias = lista.obtenerListadoCartasAleatorias();
        }

        #endregion

        #region temporizador
        /// <summary>
        /// sirve para calcular el tiempo transcurrido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Timer_Tik(object sender, object e)
        {
            string res=null;
            //Update();
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
            else
            {
                this.tiempo.Stop();
                if (this.isPartidaActiva)
                {
                    this.isPartidaActiva = false;
                    NotifyPropertyChanged("IsPartidaActiva");
                }

                if (time == 0)
                {
                    MensajePerdedor();
                    //this.isPartidaActiva = false;
                    //NotifyPropertyChanged("IsPartidaActiva");
                }
                if (res != null)
                {
                    guardarResultado();
                }
                else
                {
                    this.tiempo.Stop();
                    this.isPartidaActiva = false;
                    NotifyPropertyChanged("IsPartidaActiva");
                }
            }
        }
        #endregion temporizador

        #region propiedades publicas
        public DelegateCommand UpdateCommand
        {
            get
            {
                updateCommand = new DelegateCommand(Update);
                return updateCommand;
            }
            set
            {
                updateCommand = value;
            }
        }

        public bool IsPartidaActiva
        {
            get { return this.isPartidaActiva; }
            set { this.isPartidaActiva = value; }
        }

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

        public string Temporizador
        {
            get;
            set;
        }

        //public string NickJugador
        //{
        //    get { return nickJugador; }
        //    set { nickJugador= value;}
        //}

        #endregion

        #region metodos

        /// <summary>
        /// Metodo que inicia una nueva partida
        /// </summary>
        public void Update()
        {
            Frame FrameActual =(Frame) Window.Current.Content;
            FrameActual.Navigate(typeof(Juego));
        }
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
            if (carta1!=null && carta2!=null)
            {
                this.isPartidaActiva = false;
                NotifyPropertyChanged("IsPartidaActiva");
                if (carta2.IdCarta==carta1.IdCarta)
                {
                    parejasEncontradas++;
                    carta1=null;
                    carta2=null;
                    
                }
                else
                {
                    //para que espere un poco antes de dar la vuelta
                    
                    Task task = Task.Delay(450);
                    await task.AsAsyncAction();
                    carta1.Descubierta = false;
                    carta2.Descubierta = false;
                    carta1 = null;
                    carta2 = null;

                    //para que deseleccione la carta seleccionada para poder seleccionarla otra vez
                    cartaSeleccionada = null;
                    NotifyPropertyChanged("CartaSeleccionada");
                }
                this.isPartidaActiva = true;
                NotifyPropertyChanged("IsPartidaActiva");
            }

            if (parejasEncontradas == 6)
            {
                this.tiempo.Stop();
                
                string res=await MensajeGanador();

                if (res != null)
                {
                    guardarResultado();
                }
                //else
                //{
                //    this.isPartidaActiva = false;
                //    NotifyPropertyChanged("IsPartidaActiva");
                //}
                this.isPartidaActiva = false;
                NotifyPropertyChanged("IsPartidaActiva");
            }
        }

        /// <summary>
        /// para mostrar un dialogo que ya ha acabado la partida o que ha ganado
        /// para que introduzca el nombre
        /// </summary>
        /// <returns>el alias del jugador o nulo si cancela</returns>
        public async Task<string> MensajeGanador()
        {
            TextBox inputTextBox = new TextBox();
            inputTextBox.AcceptsReturn = false;
            inputTextBox.Height = 40;
            ContentDialog dialog = new ContentDialog();
            dialog.Content = inputTextBox;
            dialog.Title = "Has terminado!!! Introduce tu alias";
            dialog.IsSecondaryButtonEnabled = true;
            dialog.PrimaryButtonText = "Enviar";
            dialog.SecondaryButtonText = "Cancel";
            if (await dialog.ShowAsync() == ContentDialogResult.Primary)
                nickJugador = inputTextBox.Text;
            else
                nickJugador = null;

            return nickJugador;

        }

        /// <summary>
        /// para mostrar un dialogo que ya ha acabado la partida y ha perdido
        /// para que introduzca el nombre
        /// </summary>
        
        private async void MensajePerdedor()
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = "Has Perdidoooo",
                Content = "Puedes intentarlo de nuvo",
                CloseButtonText = "De acuerdo"
            };

            ContentDialogResult result = await noWifiDialog.ShowAsync();
            
        }

        /// <summary>
        /// este metodo guarda el alias y el tiempo del jugador
        /// </summary>
        private void guardarResultado()
        {
            Temporizador = string.Format("00:0{0}:{1}", time / 60, (60-(time % 60)));//es para que el tiempo se ponga bien
            
            ClsTopScore score = new ClsTopScore(nickJugador,Temporizador);
            ClsGestionTopScoreBL bl = new ClsGestionTopScoreBL();

            bl.InsertarPuntuacionBL(score);
        }
        #endregion

    }
}
