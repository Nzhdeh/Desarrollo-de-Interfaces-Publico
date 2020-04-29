using CuestionarioCoronavirusBL.ListadosBL;
using CuestionarioCoronavirusET;
using CuestionarioCoronavirusUI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CuestionarioCoronavirusUI.ViewModels
{
    public class ClsPreguntasVM : ClsVMBase
    {
        #region prpiedades privadas
        private ObservableCollection<ClsPregunta> listadoPreguntas;
        private ClsPregunta preguntaActual;//es la pregunta a la que estamos contestando en ese momento
        private ObservableCollection<ClsRespuesta> listadoRespuestasPorPregunta;
        private ClsRespuesta respuestaSeleccionada;
        private string textoAppBarButton;//el texto para el appbarbutton
        private DelegateCommand siguenteCommand;
        private bool isSiguente;//para bloquear y desbloquear el appbarbutton 
        private bool diagnostico;//para pasar a la siguente pantalla
        private double cont = 0;//solo para contar los casos positivos
        #endregion

        #region constructores
        public ClsPreguntasVM()
        {
            this.listadoPreguntas = new ClsListadoPreguntasBL().ListadoPreguntasBL();
            this.preguntaActual = listadoPreguntas[0];
            this.listadoRespuestasPorPregunta = new ClsListadoRespuestasBL().ListadoRespuestasPorPreguntaBL(preguntaActual.IdPregunta);
            this.textoAppBarButton = "Siguente pregunta";
            this.isSiguente = false;
            this.diagnostico = false;
        }

        public ClsPreguntasVM(bool diagnostico)
        {
            this.diagnostico = diagnostico;
        }
        #endregion

        #region propiedades publicas

        public bool Diagnostico
        {
            get
            {
                return diagnostico;
            }
            set
            {
                diagnostico = value;
            }
        }
        public bool IsSiguente
        {
            get
            {
                return isSiguente;
            }
            set
            {

                isSiguente = value;
            }
        }
        public string TextoAppBarButton
        {
            get
            {
                return textoAppBarButton;
            }
            set
            {

                textoAppBarButton = value;
                NotifyPropertyChanged("SiguenteCommand");

            }
        }

        public DelegateCommand SiguenteCommand
        {
            get
            {
                siguenteCommand = new DelegateCommand(siguentePregunta);
                return siguenteCommand;
            }
            set
            {
                siguenteCommand = value;
            }
        }

        public ObservableCollection<ClsPregunta> ListadoPreguntas
        {
            get
            {
                return listadoPreguntas;
            }
            set
            {
                listadoPreguntas = value;
            }
        }

        public ClsPregunta PreguntaActual
        {
            get
            {
                return preguntaActual;
            }
            set
            {
                preguntaActual = value;
            }
        }

        public ObservableCollection<ClsRespuesta> ListadoRespuestasPorPregunta
        {
            get
            {
                return listadoRespuestasPorPregunta;
            }
            set
            {
                listadoRespuestasPorPregunta = value;
            }
        }

        public ClsRespuesta RespuestaSeleccionada
        {
            get
            {
                return respuestaSeleccionada;
            }
            set
            {
                respuestaSeleccionada = value;

                if (respuestaSeleccionada != null)
                {
                    if (preguntaActual.IdPregunta == 7 && respuestaSeleccionada!=null)
                    {
                        textoAppBarButton = "Ver resultados";//cambiamos el texto del appbarbutton
                        NotifyPropertyChanged("TextoAppBarButton");
                    }

                    isSiguente = true;//desbloqueo el appbarbutton
                    NotifyPropertyChanged("IsSiguente");
                    calcularDiagnostico();
                    //diagnostico = new ClsUtil().CalcularDiagnostico(respuestaSeleccionada, listadoPreguntas);
                    respuestaSeleccionada = null;//para la siguente pregunta
                }
            }
        }
        #endregion

        #region metodos

        private void calcularDiagnostico()
        {
            if (respuestaSeleccionada.PosibleCaso == true)
            {
                cont++;
                if (cont > listadoPreguntas.Count * 0.7)
                {
                    this.diagnostico = true;
                    NotifyPropertyChanged("Diagnostico");
                }
            }
        }

        /// <summary>
        /// sirve para pasar a la siguente pregunta o si ya no hay preguntas pasa a la vista de cuestionario
        /// </summary>
        private void siguentePregunta()
        {
            if (preguntaActual.IdPregunta < 7)
            {
                preguntaActual = listadoPreguntas[preguntaActual.IdPregunta];
                NotifyPropertyChanged("PreguntaActual");
                isSiguente = false;
                NotifyPropertyChanged("IsSiguente");
                this.listadoRespuestasPorPregunta = new ClsListadoRespuestasBL().ListadoRespuestasPorPreguntaBL(preguntaActual.IdPregunta);
                NotifyPropertyChanged("ListadoRespuestasPorPregunta");
            }
            else if (textoAppBarButton=="Ver resultados")
            {
                irACuestionario();
            }
        }

        /// <summary>
        /// sirve para viajar a la vista del cuestionario
        /// </summary>
        private void irACuestionario()
        {
            Frame FrameActual = (Frame)Window.Current.Content;
            FrameActual.Navigate(typeof(CuestionarioMP), Diagnostico);
        }

        #endregion
    }
}
