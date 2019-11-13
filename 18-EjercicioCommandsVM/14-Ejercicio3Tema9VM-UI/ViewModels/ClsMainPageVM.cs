using _14_Ejercicio3Tema9_Entities;
using _14_Ejercicio3Tema9VM_UI.Models;
using _14_Ejercicio3Tema9VM_UI.Models.Utilidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace _14_Ejercicio3Tema9VM_UI.ViewModels
{
    public class ClsMainPageVM : INotifyPropertyChange
    {
        //atributos
        private ObservableCollection<ClsPersona> listaCompleta;
        private ObservableCollection<ClsPersona> listaAMostrar;
        private ClsPersona personaSeleccionada;
        private DelegateCommand eliminar;
        private DelegateCommand buscar;
        private String textoABuscar;

        //constructor por defecto
        public ClsMainPageVM()
        {
            //rellenamos la lista de personas
            this.listaCompleta = ClsListadosPersonas.listadoCompletoDePersonas();
            this.listaAMostrar = ClsListadosPersonas.listadoCompletoDePersonas();

            //definir el comportamiento de los botones(instaniciarlos)
            eliminar = new DelegateCommand(EliminarExecute, EliminarCanExecute);
            buscar = new DelegateCommand(BuscarExecute, BuscarCanExecute);
        }

        #region propiedades publicas
        //propiedades publicas
        public ClsPersona PersonaSeleccionada
        {
            get
            {
                return personaSeleccionada;
            }
            set
            {
                if (personaSeleccionada != value)//para evirtar stackoverflow
                {
                    personaSeleccionada = value;
                    eliminar.RaiseCanExecuteChanged();
                    NotificarCambioDePropiedad("PersonaSeleccionada");//nombre de la propiedad publica
                }
            }
        }

        public ObservableCollection<ClsPersona> ListadoPersonas
        {
            get
            {
                //defino elimnar comand aqui o en el constructor
                return listaAMostrar;
            }
        }

        public DelegateCommand Eliminar
        {
            get
            {
                //defino elimnar comand aqui o en el constructor
                return eliminar;
            }
        }

        public DelegateCommand Buscar
        {
            get
            {
                return buscar;
            }
        }

        public String TextoABuscar
        {
            get
            {
                return textoABuscar;
            }
            set
            {
                if (textoABuscar != value)//para evirtar stackoverflow
                {
                    textoABuscar = value;
                    
                    NotificarCambioDePropiedad("TextoABuscar");//nombre de la propiedad publica
                    buscar.RaiseCanExecuteChanged();
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombrePropiedad"></param>
        protected virtual void NotificarCambioDePropiedad([CallerMemberName] string nombrePropiedad = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }


        #region "Comandos"
        /// <summary>
        /// codigo asociado al execute del comando eliminar. 
        /// elimiará la persona seleccionada 
        /// </summary>
        private void EliminarExecute()
        {
            //Código para eliminar
            this.listaAMostrar.Remove(this.personaSeleccionada);
            //NotificarCambioDePropiedad("ListaAMostrar");//no hace falta notificar si es 
        }

        /// <summary>
        /// codigo asociado al canexecute del comando eliminar
        /// </summary>
        /// <returns>
        /// devuelve true si personaSeleccionada es distinto de null
        /// </returns>
        private bool EliminarCanExecute()
        {
            bool hayPersonaSeleccionada = true;
            if (personaSeleccionada==null)
            {
                hayPersonaSeleccionada = false;
            }
            return hayPersonaSeleccionada;
        }

        /// <summary>
        /// codigo asociado al canexecute del comando buscar
        /// </summary>
        /// <returns></returns>
        private bool BuscarCanExecute()
        {
            bool hayTextoEscrito = true;
            if(String.IsNullOrEmpty(textoABuscar))
            {
                hayTextoEscrito = false;
            }
            return hayTextoEscrito;
        }

        /// <summary>
        /// codigo asociado al execute del comando buscar
        /// buscará los nombres que contengan lo que queramos buscar
        /// </summary>
        private void BuscarExecute()
        {
            for(int i = 0; i < listaCompleta.Count; i++)
            {
                if (listaCompleta[i].Nombre.ToLower().Contains(this.textoABuscar))
                {
                    listaAMostrar.Add(listaCompleta[i]);
                }
            }
        }
        #endregion
    }
}
