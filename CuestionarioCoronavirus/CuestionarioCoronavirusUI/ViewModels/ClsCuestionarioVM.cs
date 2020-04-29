using CuestionarioCoronavirusBL.ManejadorasBL;
using CuestionarioCoronavirusET;
using CuestionarioCoronavirusUI.Views;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CuestionarioCoronavirusUI.ViewModels
{
    public class ClsCuestionarioVM : ClsVMBase
    {
        private ClsPersona persona;
        private bool diagnostico;//para poder mostrar el mensaje al usuario necesito este atributo
        private string mensajeAlUsuario;
        private string colorMensaje;
        private bool isReadOnly;
        private DelegateCommand enviarCommand;

        #region constructores
      
        public ClsCuestionarioVM()
        {
            this.persona = new ClsPersona();            
        }

        public ClsCuestionarioVM(bool diagnostico)
        {
            this.persona = new ClsPersona(diagnostico);
            this.diagnostico = diagnostico;
            this.isReadOnly = false;
            mensajeInformativo();
        }
        #endregion

        #region propiedades publicas
        public bool IsReadOnly
        {
            get
            {
                return this.isReadOnly;
            }
            set
            {
                this.isReadOnly = value;
            }
        }
        public string ColorMensaje
        {
            get
            {
                return this.colorMensaje;
            }
            set
            {
                this.colorMensaje = value;
            }
        }

        public string MensajeAlUsuario
        {
            get
            {
                return this.mensajeAlUsuario;
            }
            set
            {
                this.mensajeAlUsuario = value;
            }
        }
        
        public ClsPersona Persona
        {
            get 
            {
                return this.persona;
            }
            set 
            { 
                this.persona = value;
                
            }
        }


        public bool Diagnostico
        {
            get { return this.diagnostico; }
            set { this.diagnostico = value;  }
        }

        public DelegateCommand EnviarCommand
        {
            get
            {
                enviarCommand = new DelegateCommand(enviar);
                return enviarCommand;
            }
            set
            {
                enviarCommand = value;
            }
        }

        
        #endregion

        #region metodos


        /// <summary>
        /// sirve para guardar los datos del usuario
        /// </summary>
        private void enviar()
        {
            ClsGestionPersonaBL gestora = new ClsGestionPersonaBL();
            
            NotifyPropertyChanged("Persona.Diagnostico");
            gestora.InsertarPersonaBL(Persona);
            persona = new ClsPersona();
            NotifyPropertyChanged("Persona");//para vaciar los textboxes del cuestionarion en xaml
            isReadOnly = true;
            NotifyPropertyChanged("IsReadOnly");
        }


        /// <summary>
        /// sirve para informar al usuario de su supuesto estado de salud
        /// </summary>
        private void mensajeInformativo()
        {
            if (Diagnostico)
            {
                mensajeAlUsuario = "Posible contagio. Llame al número 900 400 061 / 955 545 060";
                colorMensaje = "Red";
            }
            else
            {
                mensajeAlUsuario = "Parece que no está contagiado";
                colorMensaje = "Green";
            }
            //NotifyPropertyChanged("ColorMensaje");
            NotifyPropertyChanged("MensajeAlUsuario");
        }
        #endregion
    }
}
