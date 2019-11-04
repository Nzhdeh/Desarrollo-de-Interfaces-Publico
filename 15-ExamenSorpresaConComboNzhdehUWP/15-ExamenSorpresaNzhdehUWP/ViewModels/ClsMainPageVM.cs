using _15_ExamenSorpresaNzhdehUWP.Models;
using _15_ExamenSorpresaNzhdehUWP.Models.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _15_ExamenSorpresaNzhdehUWP.ViewModels
{
    public class ClsMainPageVM : INotifyPropertyChanged
    {
        private List<ClsCocheMarca> listadoMarcas;
        private List<ClsCocheModelo> listadoModelos;

        private ClsCocheMarca marcaSeleccionada;
        private ClsCocheModelo modeloSeleccionado;

        private string seleccionFinal;

        public ClsMainPageVM()
        {
            this.listadoMarcas = ClsUtilListados.listadoCompletoMarcas();
        }


        #region propiedades publicas
        //propiedades publicas

        public List<ClsCocheMarca> ListadoMarcas
        {
            get
            {
                return listadoMarcas;
            }
        }

        public List<ClsCocheModelo> ListadoModelos
        {
            get
            {
                return listadoModelos;
            }
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
                this.listadoModelos = ClsUtilListados.listadoCompletoModelos(marcaSeleccionada.Id);
                NotificarCambioDePropiedad("ListadoModelos");
            }
        }

        public ClsCocheModelo ModeloSeleccionado
        {
            get
            {
                return modeloSeleccionado;
            }
            set
            {
                modeloSeleccionado = value;
                NotificarCambioDePropiedad("SeleccionFinal");
                this.seleccionFinal = "";//limpio para que cuando cambie de marca no se vea la seleccion anterior
            }
        }

        public String SeleccionFinal
        {
            get
            {
                if (marcaSeleccionada != null && modeloSeleccionado != null)
                {
                    seleccionFinal = marcaSeleccionada.Marca + " " + modeloSeleccionado.Modelo;
                }

                return seleccionFinal;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion 

        /// <summary>
        /// el encargado de notificar el cambio
        /// </summary>
        /// <param name="nombrePropiedad"></param>
        protected virtual void NotificarCambioDePropiedad([CallerMemberName] string nombrePropiedad = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }

    }
}
