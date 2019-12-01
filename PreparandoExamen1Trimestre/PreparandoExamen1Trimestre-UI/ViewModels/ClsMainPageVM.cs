using PreparandoExamen1Trimestre_BL.Listados;
using PreparandoExamen1Trimestre_ENTITIES;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreparandoExamen1Trimestre_UI.ViewModels
{
    public class ClsMainPageVM : ClsNotificarCambio
    {
        private ObservableCollection<ClsUsuario> listadoUsuarios;
        private ClsUsuario usuarioSeleccionado;
        //private List<ClsUPartido> listadoPartidos;
        //private ClsUPartido partidoSeleccionado;
        //private List<ClsApuesta> listadoApuestas;
        //private ClsApuesta apuestaSeleccionado;

        public ClsMainPageVM()
        {
            ClsListadoDeUsuariosBL listadoBL = new ClsListadoDeUsuariosBL();
            this.listadoUsuarios = new ObservableCollection<ClsUsuario>(listadoBL.ObtenerListadoUsuariosBL());
        }

        public ObservableCollection<ClsUsuario> ListadoUsuarios
        {
            get
            {
                return listadoUsuarios;
            }
        }

        public ClsUsuario UsuarioSeleccionado
        {
            get
            {
                return usuarioSeleccionado;
            }
            set
            {
                usuarioSeleccionado = value;
                NotifyPropertyChanged("usuarioSeleccionado");
            }
        }
    }
}
