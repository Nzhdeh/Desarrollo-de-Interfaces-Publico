using HospitalesSaturadosBL.ManejadorasBL;
using HospitalesSaturadosET;
using HospitalesSaturadosUI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace HospitalesSaturadosUI.ViewModels
{
    public class ClsDetallesTareaVM : ClsVMBase
    {
        #region propiedades privadas
        private ClsMedico medico;
        private string fechaActual;//la necesito para cuando el médico no tine tareas,si tiene tareas podría sacar la fecha de la tarea
        private string noTieneTarea;//por si el medico no tiene tareas para ese día
        private bool isSesionVisible;//para cuando no tenga tareas en ninguna sesion ,hace desaparecer los textblocks de las sesiones
        private ClsControlDiario tareasDeMedico;//para obtener lo que tiene que hacer el médico hoy
        private DelegateCommand salirCommand;//para el appbarbutton de salir
        #endregion

        #region constructores
        public ClsDetallesTareaVM()
        {

        }

        public ClsDetallesTareaVM(string codigo)
        {
            if (codigo != null)//aunque el codigo nunca va a estar null
            {
                this.fechaActual = DateTime.Today.ToShortDateString();
                this.noTieneTarea = "";
                this.isSesionVisible = true;
                try
                {
                    this.tareasDeMedico = new ClsGestionTareasBL().TareasPorCodigoMedicoYFechaDeHoyDAL(codigo);
                    this.medico = new ClsGestionMedicoBL().ObtenerMedicoBL(codigo);
                }
                catch (Exception)
                {
                    var dlg = new MessageDialog("Problemas de conexión. Inténtalo más tarde por favor");
                    var res = dlg.ShowAsync();
                }
            }
            else
            {
                var dlg = new MessageDialog("Código de médico nulo");
                var res = dlg.ShowAsync();
            }
            

            if (this.tareasDeMedico == null)
            {
                isSesionVisible = false;
            }
        }
        #endregion

        #region propiedades publicas
        public DelegateCommand SalirCommand
        {
            get
            {
                salirCommand = new DelegateCommand(mensajeSalida);
                return salirCommand;
            }
            set
            {
                salirCommand = value;
            }
        }

        public bool IsSesionVisible
        {
            get
            {
                return this.isSesionVisible;
            }
            set
            {
                this.isSesionVisible = value;
            }
        }

        public ClsMedico Medico
        {
            get
            {
                return this.medico;
            }
            set
            {
                this.medico = value;
            }
        }

        public string FechaActual
        {
            get
            {
                return this.fechaActual;
            }
            set
            {
                this.fechaActual = value;
            }
        }

        public string NoTieneTarea
        {
            get
            {
                return this.noTieneTarea;
            }
            set
            {
                this.noTieneTarea = value;
            }
        }

        public ClsControlDiario TareasDeMedico
        {
            get
            {
                if (tareasDeMedico == null)
                {
                    this.noTieneTarea = "Hoy no tiene tareas";
                    NotifyPropertyChanged("NoTieneTarea");
                }
                return this.tareasDeMedico;
            }
            set
            {
                this.tareasDeMedico = value;
            }
        }
        #endregion

        #region metodos
        /// <summary>
        /// sirve para salir de la visata de las tareas
        /// </summary>
        private void salir()
        {
            Frame FrameActual = (Frame)Window.Current.Content;
            FrameActual.Navigate(typeof(Acceso));
        }

        /// <summary>
        /// sirve para controlar la salida
        /// </summary>
        private async void mensajeSalida()
        {
            ContentDialog saliDialogo = new ContentDialog
            {
                Title = "¿Quieres salir?",
                PrimaryButtonText = "Salir",
                CloseButtonText = "Cancelar"
            };

            if (await saliDialogo.ShowAsync() == ContentDialogResult.Primary)
            {
                salir();
            }
        }
        #endregion
    }
}
