using CamellosBL.ListadosBL;
using CamellosBL.ManejadorasBL;
using CamellosET;
using CamellosUI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace CamellosUI.ViewModels
{
    public class ClsJuegoVM : ClsVMBase
    {
        #region propiedades privadas
        private string nick;//para recibir el nick
        private ClsPrueba pruebaActual;
        private ObservableCollection<ClsPalabras> listadoPalabrasPorPrueba;
        private string imagenCamello;
        private double moverCamello;
        private int totalDificultades;//para obtener el total de dificultades de la lista de ClsPalabras,no tiene propiedad pública
        private ClsPalabras palabraActual;
        private string palabraEscrita;//por parte del jugador
        private string tiempoMaximo = "00:00:00";
        private int minutos, segundos;//para manejar el tiempo,no tienen propiedades públicas
        private DispatcherTimer tiempo;//para poder parar y empezar el tiempo
        private DelegateCommand siguentePalabraCommand;
        private DelegateCommand salirCommand;
        //private int tamanioRelativePanel;//es para calcular bien el camino que tiene que recorrer el camello,porque no funcionaba bien,pero ya esta arreglado
        private string borderBrushPalabraEscrita;//para poner el textbox de la palabra que escribe el jugador en rojo si se equivoca
        #endregion


        #region constructores
        public ClsJuegoVM(string nick)
        {
            try
            {
                this.borderBrushPalabraEscrita = "Black";
                this.nick = nick;
                
                int id = new ClsManejadoraProgresosBL().ObtenerUltimoProgresoBL(this.nick);

                this.imagenCamello = "ms-appx:///Assets/Imagenes/camellos.gif";
                
                if (id == 0)//es la primera vez que juega
                {
                    this.pruebaActual = new ClsManejadoraPruebaBL().ObtenerPrimeraPruebaBL();
                }
                else
                {
                    this.pruebaActual = new ClsManejadoraPruebaBL().ObtenerSiguentePruebaBL(id);
                }

                if (this.pruebaActual != null)//si tengo timepo pondré que pueda volver a jugar
                {
                    this.listadoPalabrasPorPrueba = new ClsListadoPalabrasBL().ObtenerPalabrasPorIdPruebaBL(this.pruebaActual.IdPrueba);
                    if(this.listadoPalabrasPorPrueba != null)//por si hay pruebas que todavia no tienen palabras
                    {
                        obtenerTotalDificultades();
                        //calcularTamañoPantalla();
                        this.moverCamello = 0.0;
                        barjarPalabras();

                        primeraPalabra();

                        this.tiempoMaximo = this.pruebaActual.TiempoMaximo;
                        this.minutos = Convert.ToInt32(this.tiempoMaximo.Substring(3, 2));
                        this.segundos = Convert.ToInt32(this.tiempoMaximo.Substring(6, 2));

                        this.tiempo = new DispatcherTimer();

                        this.tiempo.Interval = new TimeSpan(0, 0, 1);

                        this.tiempo.Tick += Timer_Tik;
                    }
                    else
                    {
                        irAlMenu();
                        var dlg = new MessageDialog("Esta prueba aún no tiene palabras,Pronto podrás jugar. Gracias ");
                        var res = dlg.ShowAsync();
                        
                    }
                }
                else
                {
                    irAlMenu();
                    var dlg = new MessageDialog("Has superado  todas la pruebas");
                    var res = dlg.ShowAsync();
                    //nivelesSuperados();
                }               
            }
            catch (Exception)
            {
                var dlg = new MessageDialog("Problemas de conexión. Inténtalo más tarde por favor");
                var res = dlg.ShowAsync();
            }
            
        }
        public ClsJuegoVM()
        {
            this.nick = "";
        }

        public ClsJuegoVM(ClsPrueba pruebaActual, ObservableCollection<ClsPalabras> listadoPalabrasPorPrueba, string tiempoMaximo)
        {
            this.pruebaActual = pruebaActual;
            this.listadoPalabrasPorPrueba = listadoPalabrasPorPrueba;
            this.tiempoMaximo = tiempoMaximo;
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
            if (minutos > 0 && segundos > 0)
            {
                if (segundos <= 10)
                {
                    segundos--;
                    this.tiempoMaximo = string.Format("00:0{0}:0{1}", minutos % 60, segundos % 60);
                    //NotifyPropertyChanged("TiempoMaximo");

                    if (segundos == 0)
                    {
                        minutos--;
                        segundos = 59;
                    }
                    NotifyPropertyChanged("TiempoMaximo");
                }
                else
                {
                    segundos--;
                    this.tiempoMaximo = string.Format("00:0{0}:{1}", minutos % 60, segundos % 60);
                    NotifyPropertyChanged("TiempoMaximo");
                }
            }
            else if(minutos > 0 && segundos == 0)
            {
                if (minutos > 0)
                {
                    minutos--;
                    segundos = 59;
                    NotifyPropertyChanged("TiempoMaximo");
                }
                
                if (segundos <= 10)
                {
                    segundos--;
                    this.tiempoMaximo = string.Format("00:0{0}:0{1}", minutos % 60, segundos % 60);
                    //NotifyPropertyChanged("TiempoMaximo");

                    //if (minutos == 0)
                    //{
                    //    minutos--;
                    //    segundos = 59;
                    //}
                    //NotifyPropertyChanged("TiempoMaximo");
                }
                else
                {
                    segundos--;
                    this.tiempoMaximo = string.Format("00:0{0}:{1}", minutos % 60, segundos % 60);
                    //NotifyPropertyChanged("TiempoMaximo");
                }
                NotifyPropertyChanged("TiempoMaximo");
            }
            else if (minutos == 0 && segundos > 0)
            {
                //segundos = 60;

                if (segundos <= 10)
                {
                    segundos--;
                    this.tiempoMaximo = string.Format("00:0{0}:0{1}", segundos / 60, segundos % 60);
                    NotifyPropertyChanged("TiempoMaximo");

                    //if (segundos == 0)
                    //{
                    //    minutos--;//para salir de aquí
                    //}
                }
                else
                {
                    segundos--;
                    this.tiempoMaximo = string.Format("00:0{0}:{1}", segundos / 60, segundos % 60);
                    NotifyPropertyChanged("TiempoMaximo");
                }
            }
            else //if(minutos==0 && segundos==0)
            {
                this.tiempo.Stop();
                mensajePerdedor();
                                
            }
        }
        #endregion temporizador

        #region propiedades publicas
        public string BorderBrushPalabraEscrita
        {
            get
            {
                return this.borderBrushPalabraEscrita;
            }
            set
            {
                this.borderBrushPalabraEscrita = value;
            }
        }

        //public int TamanioRelativePanel
        //{
        //    get
        //    {
        //        return this.tamanioRelativePanel;
        //    }
        //    set
        //    {
        //        this.tamanioRelativePanel = value;
        //    }
        //}

        public double MoverCamello
        {
            get
            {
                return this.moverCamello;
            }
            set
            {
                this.moverCamello = value;
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

        public string ImagenCamello
        {
            get
            {
                return this.imagenCamello;
            }
            set
            {
                this.imagenCamello = value;
            }
        }

        public DelegateCommand SiguentePalabraCommand
        {
            get
            {
                this.siguentePalabraCommand = new DelegateCommand(siguentePalabra);
                return this.siguentePalabraCommand;
            }
            set
            {
                this.siguentePalabraCommand = value;
            }
        }

        public DelegateCommand SalirCommand
        {
            get
            {
                this.salirCommand = new DelegateCommand(mensajeSalida);
                return this.salirCommand;
            }
            set
            {
                this.salirCommand = value;
            }
        }

        public ClsPrueba PruebaActual
        {
            get
            {
                return this.pruebaActual;
            }
            set
            {
                this.pruebaActual = value;
            }
        }

        public ObservableCollection<ClsPalabras> ListadoPalabrasPorPrueba
        {
            get
            {
                return this.listadoPalabrasPorPrueba;
            }
            set
            {
                this.listadoPalabrasPorPrueba = value;
            }
        }

        public ClsPalabras PalabraActual
        {
            get
            {
                return this.palabraActual;
            }
            set
            {
                this.palabraActual = value;
            }
        }

        public string PalabraEscrita
        {
            get
            {
                return this.palabraEscrita;
            }
            set
            {
                this.palabraEscrita = value;

                if (this.palabraEscrita.Length == 1)//para que arranque el tiempo cuando empiece a teclear
                {
                    this.tiempo.Start();
                }
                if (this.palabraEscrita != null)
                {
                    borderBrushPalabraEscrita = "Black";
                    NotifyPropertyChanged("BorderBrushPalabraEscrita");
                }
            }
        }

        public string TiempoMaximo
        {
            get
            {
                return this.tiempoMaximo;
            }
            set
            {
                this.tiempoMaximo = value;
            }
        }

        #endregion

        #region metodos publicos
        /// <summary>
        /// para que funcione con el botón enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Btn_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                SiguentePalabraCommand.Execute(null);//llamamos a la funcion sin parametro                
            }
        }
        #endregion

        #region metodos privados

        /// <summary>
        /// para mostrar un dialogo que ya ha acabado la partida y ha perdido
        /// </summary>
        private async void mensajePerdedor()
        {
            ContentDialog perdiDialogo = new ContentDialog
            {
                Title = "Nivel no superado. ¿Quieres volver a jugar?",
                PrimaryButtonText = "Salir",
                CloseButtonText = "Repetir"
            };

            if (await perdiDialogo.ShowAsync() == ContentDialogResult.Primary)
            {
                irAlMenu();
            }
            else
            {
                repetirPrueba(); //para repetrir la misma prueba
            }
        }

        /// <summary>
        /// sirve para controlar la salida del juego
        /// </summary>
        private async void mensajeSalida()
        {
            if(this.tiempo != null)
                this.tiempo.Stop();//por si se ha equivocado,paro el tiempo para que no pierda segundos
            ContentDialog saliDialogo = new ContentDialog
            {
                Title = "¿Quieres salir del juego?",
                PrimaryButtonText = "Salir",
                CloseButtonText = "Cancelar"
            };

            if (await saliDialogo.ShowAsync() == ContentDialogResult.Primary)
            {
                irAlMenu();
            }
            else
            {
                if (this.tiempo != null)
                    this.tiempo.Start();//para que siga jugando
            }
            
        }

        /// <summary>
        /// calcula el tiempo en el que el jugador ha acabado el jugo
        /// </summary>
        private void calcularTiempoJugador()
        {
            int min = 0, seg = 0;
            string tiempoJugador = this.pruebaActual.TiempoMaximo;

            min = Convert.ToInt32(tiempoJugador.Substring(3, 2));
            seg = Convert.ToInt32(tiempoJugador.Substring(6, 2));
            TimeSpan ts = new TimeSpan(0, min, seg);
            if (minutos < 0)
            {
                minutos = 0;
            }
            TimeSpan tsJugador = new TimeSpan(0, minutos, segundos);
            TimeSpan diferencia = ts - tsJugador;

            this.tiempoMaximo = diferencia.ToString();//string.Format("00:0{0}:{1}", minutos / 60, (segundos - (segundos % 60)));//es para que el tiempo se ponga bien
        }

        /// <summary>
        /// este metodo guarda el progreso
        /// </summary>
        private void guardarProgreso()
        {
            if (this.listadoPalabrasPorPrueba.Count == 0)
            {
                calcularTiempoJugador();

                ClsPruebaJugador prog = new ClsPruebaJugador(new ClsManejadoraJugadorBL().ObtenerIdJugadorPorNickDAL(this.nick), this.pruebaActual.IdPrueba, this.tiempoMaximo);
                ClsManejadoraProgresosBL m = new ClsManejadoraProgresosBL();

                m.InsertarProgresoBL(prog);
            }
        }

        /// <summary>
        /// sirve para repetir la misma prueba si así lo decide el jugador
        /// </summary>
        private void repetirPrueba()
        {
            try
            {
                this.borderBrushPalabraEscrita = "Black";
                
                if (this.pruebaActual != null)
                {
                    this.palabraEscrita = "";
                    NotifyPropertyChanged("PalabraEscrita");
                    this.listadoPalabrasPorPrueba = new ClsListadoPalabrasBL().ObtenerPalabrasPorIdPruebaBL(this.pruebaActual.IdPrueba);//tengo que obtener las palabras de nuvo,porque borro la palabra después de mostrarla
                    obtenerTotalDificultades();
                    //calcularTamañoPantalla();
                    NotifyPropertyChanged("TamañoRelativePanel");
                    this.moverCamello = 0.0;
                    NotifyPropertyChanged("MoverCamello");
                    barjarPalabras();
                    primeraPalabra();
                    if (this.pruebaActual != null)
                    {
                        this.tiempoMaximo = this.pruebaActual.TiempoMaximo;
                        NotifyPropertyChanged("TiempoMaximo");
                        this.minutos = Convert.ToInt32(this.tiempoMaximo.Substring(3, 2));
                        this.segundos = Convert.ToInt32(this.tiempoMaximo.Substring(6, 2));

                        this.tiempo = new DispatcherTimer();
                        this.tiempo.Interval = new TimeSpan(0, 0, 1);
                        this.tiempo.Tick += Timer_Tik;
                    }
                }
                //else
                //{
                //    var dlg = new MessageDialog("¡Enhorabuenaaa!No hay más pruebas");
                //    var res = dlg.ShowAsync();
                //    irAlMenu();
                //}

            }
            catch (Exception)
            {
                var dlg = new MessageDialog("Problemas de conexión. Inténtalo más tarde por favor");
                var res = dlg.ShowAsync();
            }
        }
        /// <summary>
        /// sirve para pasar a la siguente prueba
        /// </summary>
        private void siguentePrueba()
        {
            try
            {
                this.borderBrushPalabraEscrita = "Black";
                
                this.pruebaActual = new ClsManejadoraPruebaBL().ObtenerSiguentePruebaBL(this.pruebaActual.IdPrueba);
                if (this.pruebaActual != null)
                {
                    this.listadoPalabrasPorPrueba = new ClsListadoPalabrasBL().ObtenerPalabrasPorIdPruebaBL(this.pruebaActual.IdPrueba);
                    if (this.listadoPalabrasPorPrueba != null)//por si hay pruebas que todavia no tienen palabras
                    {
                        obtenerTotalDificultades();
                        //calcularTamañoPantalla();
                        NotifyPropertyChanged("TamañoRelativePanel");
                        this.moverCamello = 0.0;
                        NotifyPropertyChanged("MoverCamello");
                        barjarPalabras();
                        primeraPalabra();


                        this.tiempoMaximo = this.pruebaActual.TiempoMaximo;
                        NotifyPropertyChanged("TiempoMaximo");
                        this.minutos = Convert.ToInt32(this.tiempoMaximo.Substring(3, 2));
                        this.segundos = Convert.ToInt32(this.tiempoMaximo.Substring(6, 2));
                        this.tiempo = new DispatcherTimer();
                        this.tiempo.Interval = new TimeSpan(0, 0, 1);
                        this.tiempo.Tick += Timer_Tik;
                    }
                    else
                    {
                        irAlMenu();
                        var dlg = new MessageDialog("Esta prueba aún no tiene palabras,Pronto podrás jugar. Gracias ");
                        var res = dlg.ShowAsync();
                       
                    }
                }
                else
                {
                    irAlMenu();
                    var dlg = new MessageDialog("¡Enhorabuenaaa!No hay más pruebas");
                    var res = dlg.ShowAsync();
                    
                }
                
            }
            catch (Exception)
            {
                var dlg = new MessageDialog("Problemas de conexión. Inténtalo más tarde por favor");
                var res = dlg.ShowAsync();
            }
        }

        /// <summary>
        /// sirve para pasar a la siguente palabra
        /// </summary>
        private void siguentePalabra()
        {
            if (this.listadoPalabrasPorPrueba !=null)
            {
                if (this.palabraActual.Palabra.ToLower().Equals(this.palabraEscrita.ToLower()))
                {
                    this.moverCamello += Convert.ToInt32(Convert.ToDouble(Math.Round((this.palabraActual.Dificultad * (1000.0 / this.totalDificultades)))));
                    NotifyPropertyChanged("MoverCamello");

                    primeraPalabra();

                    this.palabraEscrita = "";
                    NotifyPropertyChanged("PalabraEscrita");
                }
                else
                {
                    this.borderBrushPalabraEscrita = "Red";
                    NotifyPropertyChanged("BorderBrushPalabraEscrita");
                }
            }
            else
            {
                this.tiempo.Stop();
            }
        }

        /// <summary>
        /// sirve para calcular el tamaño del cuadrado donde esta el camello
        /// </summary>
        //private void calcularTamañoPantalla()
        //{
        //    this.tamanioRelativePanel = 0;
        //    this.tamanioRelativePanel = Convert.ToInt32(Convert.ToDouble(Math.Round((this.totalDificultades * (1000.0 / this.totalDificultades)) + 100.0)));//sumo 100 por el tamaño del gif
        //}

        /// <summary>
        /// obtiene el total de dificultades de la lista de ClsPalabras
        /// </summary>
        /// <returns></returns>
        private void obtenerTotalDificultades()
        {
            this.totalDificultades = 0;
            for (int i = 0; i < listadoPalabrasPorPrueba.Count; i++)
            {
                this.totalDificultades += this.listadoPalabrasPorPrueba[i].Dificultad;
            }
        }

        /// <summary>
        /// sirve para obtener la primera palabra de la lista de ClsPalabras
        /// </summary>
        private void primeraPalabra()
        {
            if(listadoPalabrasPorPrueba.Count > 0)
            {
                this.palabraActual = listadoPalabrasPorPrueba[0];
                NotifyPropertyChanged("PalabraActual");
                listadoPalabrasPorPrueba.Remove(listadoPalabrasPorPrueba[0]);
            }
            else
            {
                //TODO saltaria lo de pasar a la siguente nivel si ha ido todo bien
                this.tiempo.Stop();
                //guardarProgreso();
                this.palabraEscrita = "";
                NotifyPropertyChanged("PalabraEscrita");
                //siguentePrueba();
                seguirJugando();
            }            
        }

        /// <summary>
        /// sirve para barajar las palabras para que no salgan siempre en el mismo orden
        /// </summary>
        private void barjarPalabras()
        {
            //a continuacion se barajan las palabras
            ObservableCollection<ClsPalabras> arrDesordenado = new ObservableCollection<ClsPalabras>();

            Random randNum = new Random();
            while (this.listadoPalabrasPorPrueba.Count > 0)
            {
                int val = randNum.Next(0, this.listadoPalabrasPorPrueba.Count - 1);
                arrDesordenado.Add(this.listadoPalabrasPorPrueba[val]);
                this.listadoPalabrasPorPrueba.RemoveAt(val);//elimina el elemento para que no se repitan
            }

            this.listadoPalabrasPorPrueba = arrDesordenado;
            NotifyPropertyChanged("ListadoPalabrasPorPrueba");
        }

        /// <summary>
        /// sirve para controlar si quiere seguir jugando cuando acabe un nivel o no
        /// </summary>
        private async void seguirJugando()
        {
            this.tiempo.Stop();
            
            ContentDialog saliDialogo = new ContentDialog
            {
                Title = "Nivel completadooo.Si deseas salir se guardarán tus progresos ¿Quieres seguir jugando?",
                PrimaryButtonText = "No",
                CloseButtonText = "Seguir jugando"
            };
            

            if (await saliDialogo.ShowAsync() == ContentDialogResult.Primary)
            {
                
                guardarProgreso();
                irAlMenu();
            }
            else
            {
                guardarProgreso();
                siguentePrueba();
            }
        }

        /// <summary>
        /// sirve para cuando no haya más niveles vaya al menú principal
        /// </summary>
        private async void nivelesSuperados()
        {
            ContentDialog saliDialogo = new ContentDialog
            {
                Title = "No hay más pruebas. Pronto habrá nuevos niveles. Gracias",
                PrimaryButtonText = "Ir al menú",
            };


            if (await saliDialogo.ShowAsync() == ContentDialogResult.Primary)
            {
                irAlMenu();
            }
        }

        private void irAlMenu()
        {
            Frame FrameActual = (Frame)Window.Current.Content;
            FrameActual.Navigate(typeof(Menu),this.nick);
        }
        #endregion
    }
}
