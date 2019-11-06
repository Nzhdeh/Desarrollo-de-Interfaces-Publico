using _14_Ejercicio3Tema9_Entities;
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
        private ClsPersona _personaSeleccionada;
        private ObservableCollection<ClsPersona> _listadoPersonas;

        //constructor por defecto
        public ClsMainPageVM()
        {
            //rellenamos la lista de personas
            this._listadoPersonas = ClsListadosPersonas.listadoCompletoDePersonas();
        }

        //propiedades publicas
        public ClsPersona PersonaSeleccionada
        {
            get
            {
                return _personaSeleccionada;
            }
            set
            {
                if (_personaSeleccionada != value)//para evirtar stackoverflow
                {
                    _personaSeleccionada = value;
                    NotificarCambioDePropiedad("PersonaSeleccionada");//nombre de la propiedad publica
                }
            }
        }

        public ObservableCollection<ClsPersona> ListadoPersonas
        {
            get
            {
                return _listadoPersonas;
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
            this._listadoPersonas.Remove(this._personaSeleccionada);
            //NotificarCambioDePropiedad("ListadoPersonas");
        }
    }
}
