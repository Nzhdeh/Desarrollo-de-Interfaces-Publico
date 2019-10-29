using _14_Ejercicio3Tema9_Entities;
using _14_Ejercicio3Tema9VM_UI.Models.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Ejercicio3Tema9VM_UI.ViewModels
{
    public class ClsMainPageVM : INotifyPropertyChange
    {
        //atributos
        private ClsPersona _personaSeleccionada;
        private List<ClsPersona> _listadoPersonas;

        public event PropertyChangedEventHandler PropertyChanged;

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
                _personaSeleccionada = value;
                OnPropertyChanged("PersonaSeleccionada");//nombre de la propiedad publica
            }
        }

        public List<ClsPersona> ListadoPersonas
        {
            get
            {
                return _listadoPersonas;
            }
        }

        /// <summary>
        /// no entiendo nada
        /// </summary>
        /// <param name="name"></param>
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public interface INotifyPropertyChange
    {

    }
}
