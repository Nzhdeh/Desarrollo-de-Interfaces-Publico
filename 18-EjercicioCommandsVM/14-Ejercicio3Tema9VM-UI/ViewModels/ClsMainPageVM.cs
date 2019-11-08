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
            this.listaAMostrar = listaCompleta;
        }

        //propiedades publicas
        public ClsPersona PersonaSeleccionada
        {
            get
            {
                return personaSeleccionada;
            }
            set
            {
                //if (personaSeleccionada != value)//para evirtar stackoverflow
                //{
                    personaSeleccionada = value;
                    NotificarCambioDePropiedad("PersonaSeleccionada");//nombre de la propiedad publica
                //}
            }
        }

        public ObservableCollection<ClsPersona> ListadoPersonas
        {
            get
            {
                return listaAMostrar;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombrePropiedad"></param>
        protected virtual void NotificarCambioDePropiedad([CallerMemberName] string nombrePropiedad = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }

        /// <summary>
        /// elimina una persona
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            //Código para eliminar
            this.listaAMostrar.Remove(this.personaSeleccionada);
            //NotificarCambioDePropiedad("ListadoPersonas");
        }
    }
}
