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
        private string textoBuscado;

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

                if (ciudadSeleccionada!=null)//porque cunado borraba el texto a buscar me daba null pointer exception
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

        public string TextoBuscado
        {
            get
            {
                return textoBuscado;
            }
            set
            {
                textoBuscado = value;
                filtrarCiudades();
            }
        }
        #endregion


        #region metodos
        /// <summary>
        /// sirve para cargar el listado de las ciudades
        /// </summary>
        private async void cargarListadoCiudades()
        {
            try
            {
                ClsListadoCiudadesBL listBL = new ClsListadoCiudadesBL();
                this.listadoCiudadesCompleta = new ObservableCollection<ClsCiudad>();
                this.listadoCiudadesCompleta = await listBL.listadoCiudadesBL();

                this.listadoCiudadesFiltradas = this.listadoCiudadesCompleta;
                NotifyPropertyChanged("ListadoCiudadesFiltradas");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// sirve para cargar el listado de las predicciones de una ciudad
        /// </summary>
        private async void cargarListadoPredicciones()
        {
            try
            {
                ClsListadoPrediccionesBL listBL = new ClsListadoPrediccionesBL();
                this.listadoPredicciones = new ObservableCollection<ClsPrediccion>();
                this.listadoPredicciones = await listBL.listadoPrediccionPorCiudadDAL(ciudadSeleccionada.IdCiudad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            cargarImagenesPronostico();
        }

        /// <summary>
        /// sirve para asiganr las imagenes correspondientes a cada pronostico
        /// </summary>
        private void cargarImagenesPronostico()
        {
            for (int i = 0; i < listadoPredicciones.Count; i++)
            {
                listadoPredicciones[i].Pronostico = "ms-appx:///Assets/Imagenes/" + listadoPredicciones[i].Pronostico + ".png";//la imagen de Albacete no sale porque en la api esta mal escrito
                NotifyPropertyChanged("ListadoPredicciones");
            }
        }

        /// <summary>
        /// sirve para filtrar las ciudades para la busqueda
        /// </summary>
        private void filtrarCiudades()
        {
            ObservableCollection<ClsCiudad> auxiliar = new ObservableCollection<ClsCiudad>();

            if (!String.IsNullOrWhiteSpace(TextoBuscado))
            {
                for (int i = 0; i < listadoCiudadesFiltradas.Count; i++)
                {
                    if (listadoCiudadesFiltradas[i].NombreCiudad.ToLower().Contains(textoBuscado.ToLower()))
                    {
                        auxiliar.Add(listadoCiudadesFiltradas[i]);
                    }
                }

                listadoCiudadesFiltradas = auxiliar;
                NotifyPropertyChanged("ListadoCiudadesFiltradas");
            }
            else
            {
                listadoCiudadesFiltradas = listadoCiudadesCompleta;
                NotifyPropertyChanged("ListadoCiudadesFiltradas");
            }
        }
        #endregion
    }
}
