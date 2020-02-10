using ExamenAnimacionesUWPBL.ListadosBL;
using ExamenAnimacionesUWPET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenAnimacionesUWPUI.ViewModels
{
    public class ClsMainPageVM : ClsVMBase
    {
        #region propiedades privadas
        private ClsCiudad ciudadSeleccionada;
        private ObservableCollection<ClsCiudad> listadoCiudadesCompleta;
        private ObservableCollection<ClsCiudad> listadoCiudadesFiltradas;
        private ObservableCollection<ClsPrediccion> listadoPredicciones;
        #endregion

        #region constructores
        public ClsMainPageVM()
        {
            try
            {
                cargarListadoCiudades();
            }catch(Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region propiedades publicas
        public ObservableCollection<ClsCiudad> ListadoCiudadesCompleta
        {
            get
            {
                return listadoCiudadesCompleta;
            }
            set
            {
                listadoCiudadesCompleta = value;
                NotifyPropertyChanged("CiudadSeleccionada");
            }
        }

        public ClsCiudad CiudadSeleccionada
        {
            get
            {
                return ciudadSeleccionada;
            }
            set
            {
                ciudadSeleccionada = value;
                cargarListadoPredicciones();
            }
        }

        

        public ObservableCollection<ClsCiudad> ListadoCiudadesFiltradas
        {
            get
            {
                return listadoCiudadesFiltradas;
            }
            set
            {
                listadoCiudadesFiltradas = value;
                NotifyPropertyChanged("ListadoPredicciones");
                NotifyPropertyChanged("CiudadSeleccionada");
            }
        }

        public ObservableCollection<ClsPrediccion> ListadoPredicciones
        {
            get
            {
                return listadoPredicciones;
            }
            set
            {
                listadoPredicciones = value;
            }
        }
        #endregion


        #region metodos
        /// <summary>
        /// sirve para cargar el listado de las ciudades
        /// </summary>
        private async void cargarListadoCiudades()
        {
            ClsListadoCiudadesBL listBL = new ClsListadoCiudadesBL();
            this.listadoCiudadesCompleta = new ObservableCollection<ClsCiudad>();
            this.listadoCiudadesCompleta = await listBL.listadoCiudadesBL();

            this.listadoCiudadesFiltradas = this.listadoCiudadesCompleta;
            NotifyPropertyChanged("ListadoCiudadesFiltradas");
        }

        /// <summary>
        /// sirve para cargar el listado de las predicciones de una ciudad
        /// </summary>
        private async void cargarListadoPredicciones()
        {
            ClsListadoCiudadesBL listBL = new ClsListadoCiudadesBL();
            this.listadoPredicciones = new ObservableCollection<ClsPrediccion>();
            this.listadoPredicciones = await listBL.listadoPrediccionPorCiudadDAL(ciudadSeleccionada.IdCiudad);

            NotifyPropertyChanged("ListadoPredicciones");
        }
        #endregion
    }
}
