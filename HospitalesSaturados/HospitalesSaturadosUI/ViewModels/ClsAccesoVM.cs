using HospitalesSaturadosBL.ManejadorasBL;
using HospitalesSaturadosET;
using HospitalesSaturadosUI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace HospitalesSaturadosUI.ViewModels
{
    public class ClsAccesoVM : ClsVMBase
    {
        #region propiedades privadas
        private string mensajeDeError;
        private string codigoMedicoIntroducido;
        private DelegateCommand entrarCommand;
        private bool progressRing;
        private string borderBrush;

        #endregion

        #region constructores
        public ClsAccesoVM()
        {
            progressRing = false;
            borderBrush = "Black";
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
        public string BorderBrush
        {
            get
            {
                return this.borderBrush;
            }
            set
            {
                this.borderBrush = value;
            }
        }

        public string MensajeDeError
        {
            get
            {
                return this.mensajeDeError;
            }
            set
            {
                this.mensajeDeError = value;
            }
        }

        public string CodigoMedicoIntroducido
        {
            get
            {
                return this.codigoMedicoIntroducido;
            }
            set
            {
                this.codigoMedicoIntroducido = value;
                if (codigoMedicoIntroducido != null)
                {
                    borderBrush = "Black";
                    NotifyPropertyChanged("BorderBrush");
                    mensajeDeError = "";//para que desaparazca el mensaje de error cada vez que intenta poner un código válido
                    NotifyPropertyChanged("MensajeDeError");
                }
            }
        }

        public DelegateCommand EntrarCommand
        {
            get
            {
                entrarCommand = new DelegateCommand(entrar);
                return entrarCommand;
            }
            set
            {
                entrarCommand = value;
            }
        }
        #endregion

        #region metodos
        /// <summary>
        /// sirve para pasar a la siguente pantalla si el codigo introdicido es válido y corresponde a algún médico
        /// </summary>
        private void entrar()
        {
            try
            {

                //if (codigoMedicoIntroducido == null)//quería poner esta condición, pero en el ejercicio pedía solo "médico no encontrado" y "código no correcto(Ejemplo: 000AAA0000)"
                //{
                //    mensajeDeError = "No puede estar vacío";
                //    NotifyPropertyChanged("MensajeDeError");
                //}
                //else 
                if (isCodigoMedicoValido() && new ClsGestionMedicoBL().ExisteMedicoBL(CodigoMedicoIntroducido))
                {
                    progressRing = true;
                    NotifyPropertyChanged("ProgressRing");
                    irALasTareas();
                }
                else if (isCodigoMedicoValido() && !new ClsGestionMedicoBL().ExisteMedicoBL(CodigoMedicoIntroducido))
                {
                    mensajeDeError = "médico no encontrado";
                    NotifyPropertyChanged("MensajeDeError");

                    borderBrush = "Red";
                    NotifyPropertyChanged("BorderBrush");
                }
                else if (!isCodigoMedicoValido())
                {
                    mensajeDeError = "código no correcto(Ejemplo: 000AAA0000)";
                    NotifyPropertyChanged("MensajeDeError");
                    borderBrush = "Red";
                    NotifyPropertyChanged("BorderBrush");
                }
            }
            catch (Exception)//por si falla el método ExisteMedicoBL()
            {
                //por si no hay conexion o la cadena esta mal puesta y ExisteMedicoBL(CodigoMedicoIntroducido) falla
                var dlg = new MessageDialog("Problemas de conexión. Inténtalo más tarde por favor");
                var res = dlg.ShowAsync();
            }
        }

        /// <summary>
        /// sirve para viajar a la vista de los detalles de las tareas
        /// </summary>
        private void irALasTareas()
        {
            Frame FrameActual = (Frame)Window.Current.Content;
            FrameActual.Navigate(typeof(DetallesTarea), CodigoMedicoIntroducido);
        }

        /// <summary>
        /// comprueba si el codigo de medico introducido por el usuario es correcto
        /// </summary>
        /// <returns>true si es correcto y false si no</returns>
        private bool isCodigoMedicoValido()
        {
            bool res = false;
            
            if(codigoMedicoIntroducido!=null)
            {
                if (codigoMedicoIntroducido.Length == 10 && 
                    Regex.IsMatch(codigoMedicoIntroducido.Substring(0, 3), @"(?:.*[0-9]){3}") && 
                    Regex.IsMatch(codigoMedicoIntroducido.Substring(3, 3), @"(?:.*[A-Z]){3}") &&
                    Regex.IsMatch(codigoMedicoIntroducido.Substring(6, 4), @"(?:.*[0-9]){4}"))
                {
                    res = true;
                }
            }
            
            return res;
        }
        #endregion
    }
}
