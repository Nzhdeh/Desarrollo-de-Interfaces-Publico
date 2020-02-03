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
        private DelegateCommand volverMenuPrincipal;
        private DispatcherTimer tiempo;
        private int temporizador = 120;
        private string nickJugador;
        #endregion


        #region constructores
        public JuegoVM()
        {
            ClsObtenerListadoCartasAleatorias lista = new ClsObtenerListadoCartasAleatorias();
            listadoCartasAleatorias = lista.obtenerListadoCartasAleatorias();
        }

        #endregion

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
                //NotifyPropertyChanged("CartaSeleccionada");
                //if (cartaSeleccionada.Descubierta)
                //{
                //    cartaSeleccionada = null;
                //}
                //else
                //{
                    this.comprobarJugada();
                //}
            }
        }



        //public ClsCarta Carta1
        //{
        //    get { return this.carta1; }
        //    set { this.carta1 = value; }
        //}
        //public ClsCarta Carta2
        //{
        //    get { return this.carta2; }
        //    set { this.carta2 = value; }
        //}

        public DelegateCommand VolverMenuPrincipal
        {
            get { return this.volverMenuPrincipal; }
            set { this.volverMenuPrincipal = value; }
        }

        public int Temporizador
        {
            get { return this.temporizador; }
            set { this.temporizador = value; }
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
        }

        /// <summary>
        /// para mostrar un dialogo que ya ha acabado la partida o que ha ganado
        /// para que introduzca el nombre
        /// </summary>
        /// <returns></returns>
        public void MensajeGanador()
        {

        }
        #endregion

    }
}
