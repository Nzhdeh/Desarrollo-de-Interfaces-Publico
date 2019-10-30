using _15_ExamenSorpresaNzhdehUWP.Models;
using _15_ExamenSorpresaNzhdehUWP.Models.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_ExamenSorpresaNzhdehUWP.ViewModels
{
    public class ClsMainPageVM : INotifyPropertyChange
    {
        private List<ClsCocheMarca> listadoMarcas;
        private List<ClsCocheModelo> listadoModelos;

        private ClsCocheMarca marcaSeleccionada;
        private ClsCocheModelo modeloSeleccionado;


        public ClsMainPageVM()
        {
            listadoMarcas = ClsUtilListados.listadoCompletoMarcas();
            listadoModelos = ClsUtilListados.listadoCompletoModelos(1);
        }

        public ClsCocheMarca MarcaSeleccionada
        {
            get
            {
                return marcaSeleccionada;
            }
            set
            {
                marcaSeleccionada = value;
                //OnPropertyChanged("MarcaSeleccionada");//nombre de la propiedad publica
            }
        }

        public List<ClsCocheMarca> ListadoMarcas
        {
            get
            {
                return listadoMarcas;
            }
        }

        public ClsCocheMarca ModeloSeleccionada
        {
            get
            {
                return modeloSeleccionado;
            }
            set
            {
                modeloSeleccionado = value;
                //OnPropertyChanged("ModeloSeleccionada");//nombre de la propiedad publica
            }
        }

        public List<ClsCocheModelo> ListadoModelos
        {
            get
            {
                return listadoModelos;
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
}
