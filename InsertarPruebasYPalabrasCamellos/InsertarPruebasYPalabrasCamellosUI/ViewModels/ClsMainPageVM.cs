using InsertarPruebasYPalabrasCamellosBL.ListadosBL;
using InsertarPruebasYPalabrasCamellosBL.ManejadorasBL;
using InsertarPruebasYPalabrasCamellosET;
using InsertarPruebasYPalabrasCamellosUI.Utilidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace InsertarPruebasYPalabrasCamellosUI.ViewModels
{
    public class ClsMainPageVM : ClsVMBase
    {
        private ClsPalabras palabraIntroducida;
        private ObservableCollection<ClsPalabras> listadoPalabras;
        private ClsPalabras palabraSeleccionda;
        private string mensajeError;
        private ClsPrueba prueba;
        private int minutos, segundos;
        private DelegateCommand aniadirPalabraCommand;
        private DelegateCommand guardarCommand;
        private DelegateCommand eliminarCommand;

        #region constructores
        public ClsMainPageVM()
        {
            this.mensajeError = "";
            this.palabraIntroducida = new ClsPalabras();
            this.listadoPalabras = new ObservableCollection<ClsPalabras>();
            this.palabraSeleccionda = new ClsPalabras();
            this.prueba = new ClsPrueba();
            this.minutos = 0;
            this.segundos = 0;
        }

        public ClsMainPageVM(ClsPalabras palabraIntroducida, ObservableCollection<ClsPalabras> listadoPalabras, ClsPalabras palabraSeleccionda, ClsPrueba prueba, int minutos, int segundos, DelegateCommand aniadirPalabraCommand, DelegateCommand guardarCommand)
        {
            this.palabraIntroducida = palabraIntroducida;
            this.listadoPalabras = listadoPalabras;
            this.palabraSeleccionda = palabraSeleccionda;
            this.prueba = prueba;
            this.minutos = minutos;
            this.segundos = segundos;
            this.aniadirPalabraCommand = aniadirPalabraCommand;
            this.guardarCommand = guardarCommand;
        }
        #endregion

        #region propiedades publicas
        public string MensajeError
        {
            get
            {
                return this.mensajeError;
            }
            set
            {
                this.mensajeError = value;
            }
        }
        public ClsPalabras PalabraIntroducida
        {
            get
            {
                if (this.palabraIntroducida.Palabra != "" || this.palabraIntroducida.Dificultad != 0)
                {
                    this.mensajeError = "";
                    NotifyPropertyChanged("MensajeError");
                }
                return this.palabraIntroducida;
            }
            set
            {
                this.palabraIntroducida = value;

                if (this.palabraIntroducida.Palabra != "" || this.palabraIntroducida.Dificultad != 0)
                {
                    this.mensajeError = "";
                    NotifyPropertyChanged("MensajeError");
                }
            }
        }

        public ObservableCollection<ClsPalabras> ListadoPalabras
        {
            get
            {
                return this.listadoPalabras;
            }
            set
            {
                this.listadoPalabras = value;
            }
        }

        public ClsPalabras PalabraSeleccionda
        {
            get
            {
                return this.palabraSeleccionda;
            }
            set
            {
                this.palabraSeleccionda = value;
            }
        }

        public ClsPrueba Prueba
        {
            get
            {
                return this.prueba;
            }
            set
            {
                this.prueba = value;
            }
        }

        public int Minutos
        {
            get
            {
                return this.minutos;
            }
            set
            {
                this.minutos = value;
            }
        }

        public int Segundos
        {
            get
            {
                return this.segundos;
            }
            set
            {
                this.segundos = value;
            }
        }

        public DelegateCommand AniadirPalabraCommand
        {
            get
            {
                this.aniadirPalabraCommand = new DelegateCommand(aniadirPalabra);
                return this.aniadirPalabraCommand;
            }
            set
            {
                this.aniadirPalabraCommand = value;
            }
        }

        public DelegateCommand GuardarCommand
        {
            get
            {
                this.guardarCommand = new DelegateCommand(guardar);
                return this.guardarCommand;
            }
            set
            {
                this.guardarCommand = value;
            }
        }

        public DelegateCommand EliminarCommand
        {
            get
            {
                this.eliminarCommand = new DelegateCommand(eliminar);
                return this.eliminarCommand;
            }
            set
            {
                this.eliminarCommand = value;
            }
        }
        #endregion

        #region metodos privados
        /// <summary>
        /// añade una palabra a la lista de palabras
        /// </summary>
        private  void aniadirPalabra()
        {
            if(this.palabraIntroducida.Palabra!="" && this.palabraIntroducida.Dificultad != 0)
            {
                sumarTiempoMaximo();
                listadoPalabras.Add(new ClsPalabras(palabraIntroducida));//trabajo con la copia porque la nueva palabra machaca a las otras ,y no sé porque la verdad
                
                this.palabraIntroducida.Palabra = "";
                this.palabraIntroducida.Dificultad = 0;
                
                NotifyPropertyChanged("PalabraIntroducida");
            }
            else
            {
                //TODO avisar de que tiene que escribir la  palabra y la dificultad
                this.mensajeError = "El campo del nombre no puede estar vació \ny la dificultad tiene que ser mayor que 0";
                NotifyPropertyChanged("MensajeError");
            }
        }

        /// <summary>
        /// primero  inserta la prueba
        /// segundo obtiene el id de esa prueba
        /// sercero inserta las palabras
        /// cuarto obtiene los ids de esas palabras
        /// quinto inserta en la tabla intermedia CJ_PruebasPalabras
        /// </summary>
        private void guardar()
        {
            int exito = 0;
            int idUltimaPrueba = 0;
            List<int> idsUltimasPalabras= null;
            
            if (listadoPalabras.Count > 9)//tiene que insertar al menos 10 palabras
            {
                try
                {
                    this.prueba.NumeroPalabras = listadoPalabras.Count;
                    exito = new ClsManejadoraPruebaBL().InsertarPruebaBL(this.prueba);

                    if (exito > 0)
                    {
                        idUltimaPrueba = new ClsManejadoraPruebaBL().ObtenerIdUltimaPruebaBL();

                        for (int i = 0; i < listadoPalabras.Count; i++)
                        {
                            new ClsManejadoraPalabraBL().InsertarPalabraBL(listadoPalabras[i]);
                        }

                        idsUltimasPalabras = new ClsListadoUltimasNPalabrasBL().ObtenerIdsDeUltimasNPalabrasBL(listadoPalabras.Count);

                        for (int i = 0; i < idsUltimasPalabras.Count; i++)
                        {
                            new ClsManejadoraPruebaPalabraBL().InsertarPruebaPalabrasDAL(idUltimaPrueba, idsUltimasPalabras[i]);
                        }

                        listadoPalabras = new ObservableCollection<ClsPalabras>();
                        NotifyPropertyChanged("ListadoPalabras");
                    }
                    else
                    {
                        var dlg = new MessageDialog("La prueba no se ha insertado correctamente");
                        var res = dlg.ShowAsync();
                    }
                }
                catch (Exception)
                {
                    var dlg = new MessageDialog("Problemas de conexión. Inténtalo más tarde por favor");
                    var res = dlg.ShowAsync();
                }
            }
            else
            {
                var dlg = new MessageDialog("Hay que insertar al menos 10 palabras");
                var res = dlg.ShowAsync();
            }
            
        }

        /// <summary>
        /// elimina la linea seleccionada de una lista
        /// </summary>
        private void eliminar()
        {
            if (this.listadoPalabras.Count > 0)
            {
                restarTiempoMaximo();
                this.listadoPalabras.Remove(this.palabraSeleccionda);
                NotifyPropertyChanged("ListadoPalabras");
            }            
        }

        /// <summary>
        /// sirve para restar los segundos del tiempo maximo de la prueba
        /// </summary>
        private void restarTiempoMaximo()
        {
            segundos -= palabraSeleccionda.Dificultad;

            if (segundos <= 0 && minutos > 0)
            {
                minutos--;
                segundos = 60 + segundos;
            }

            if (minutos < 10 && segundos < 10)
            {
                this.prueba.TiempoMaximo = string.Format("00:0{0}:0{1}", minutos, segundos % 60);
            }
            else if (minutos < 10 && segundos >= 10)
            {
                this.prueba.TiempoMaximo = string.Format("00:0{0}:{1}", minutos, segundos % 60);
            }
            else if (minutos >= 10 && segundos < 10)
            {
                this.prueba.TiempoMaximo = string.Format("00:{0}:0{1}", minutos, segundos % 60);
            }
            else if (minutos >= 10 && segundos >= 10)
            {
                this.prueba.TiempoMaximo = string.Format("00:{0}:{1}", minutos, segundos % 60);
            }

            NotifyPropertyChanged("Prueba");
        }

        /// <summary>
        /// sirve para sumar los segundos al tiempo maximo de la prueba
        /// </summary>
        private void sumarTiempoMaximo()
        {
            segundos += palabraIntroducida.Dificultad;

            if (segundos > 59)
            {
                minutos++;
                segundos = segundos - 60;
            }

            if(minutos<10 && segundos < 10)
            {
                this.prueba.TiempoMaximo = string.Format("00:0{0}:0{1}", minutos, segundos % 60);
            }
            else if(minutos<10 && segundos >= 10)
            {
                this.prueba.TiempoMaximo = string.Format("00:0{0}:{1}", minutos, segundos % 60);
            }
            else if (minutos>=10 && segundos<10)
            {
                this.prueba.TiempoMaximo = string.Format("00:{0}:0{1}", minutos, segundos % 60);
            }
            else if (minutos>=10 && segundos>=10)
            {
                this.prueba.TiempoMaximo = string.Format("00:{0}:{1}", minutos, segundos % 60);
            }
            
            NotifyPropertyChanged("Prueba");
        }

        #endregion
    }
}
