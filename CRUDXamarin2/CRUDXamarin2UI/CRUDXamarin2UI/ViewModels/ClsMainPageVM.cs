using CRUDXamarin2BL.ListadosBL;
using CRUDXamarin2ET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CRUDXamarin2UI.ViewModels
{
    public class ClsMainPageVM : ClsVMBase
    {
        private ObservableCollection<ClsPersona> listadoPersonas;
        private ObservableCollection<ClsPersona> listadoPersonaAuxiliar;
        private ObservableCollection<ClsPersona> listadoDepartamentos;
        private ClsDepartamento departamentoSeleccionado;
        private ClsPersona personaSeleccionada;

        public ClsMainPageVM()
        {
            //ClsListadoPersonasBL listadoPersonasBL = new ClsListadoPersonasBL();
            //listadoPersonas = new ObservableCollection<ClsPersona>(listadoPersonasBL.getListadoPersonasBL());
            //listadoPersonaAuxiliar = listadoPersonas;
            //textoBusqueda = "";
            //DispatcherTimerSample();
            CargarListado();

        }

        public ObservableCollection<ClsPersona> ListadoPersona
        {
            get
            {
                return listadoPersonas;
            }
        }

        public ObservableCollection<ClsPersona> ListadoPersonaAuxiliar
        {
            get
            {
                return listadoPersonaAuxiliar;
            }

            set
            {
                listadoPersonaAuxiliar = value;
                NotifyPropertyChanged("listadoPersonaAuxiliar");
            }
        }
        public ObservableCollection<ClsPersona> ListadoDepartamentos
        {
            get
            {
                return listadoDepartamentos;
            }
        }

        public ClsPersona PersonaSeleccionada
        {
            get
            {
                return personaSeleccionada;
            }

            set
            {
                personaSeleccionada = value;
                //borrarCommand.RaiseCanExecuteChanged();
                //saveCommand.RaiseCanExecuteChanged();
                NotifyPropertyChanged("personaSeleccionada");
            }
        }

        public ClsDepartamento DepartamentoSeleccionado
        {
            get
            {
                return departamentoSeleccionado;
            }

            set
            {
                departamentoSeleccionado = value;
                NotifyPropertyChanged("departamentoSeleccionado");
            }
        }

        private async void CargarListado()
        {
            ClsListadoPersonasBL listadoPersonasBL = new ClsListadoPersonasBL();
            listadoPersonas = new ObservableCollection<ClsPersona>(await listadoPersonasBL.getListadoPersonasBL());
            listadoPersonaAuxiliar = listadoPersonas;
        }
    }
}
