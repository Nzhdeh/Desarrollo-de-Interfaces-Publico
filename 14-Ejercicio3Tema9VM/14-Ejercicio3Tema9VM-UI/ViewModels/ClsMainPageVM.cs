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
    public class ClsMainPageVM : ClsVMBase
    {
        //atributos
        private ClsPersona _personaSeleccionada;
        private List<ClsPersona> _listadoPersonas;

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
                NotifyPropertyChanged();//nombre de la propiedad publica
            }
        }

        public List<ClsPersona> ListadoPersonas
        {
            get
            {
                return _listadoPersonas;
            }
        }
    }
}
