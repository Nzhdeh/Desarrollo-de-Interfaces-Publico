using Examen1trimestreNzhdehUWP.Listados;
using Examen1trimestreNzhdehUWP.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*nzhdeh*/
namespace Examen1trimestreNzhdehUWP.ViewModel
{
    public class ClsMainPageVM: ClsNotificarCambio
    {
        private List<ClsVengadorConFoto> listadoVengadoresConFoto;
        private ClsVengadorConFoto vengadorSeleccionado;

        private List<ClsMision> listadoMisiones;
        private ClsMision misionSeleccionada;

        public ClsMainPageVM()
        {
            ClsListadoVengadoresConFoto listado = new ClsListadoVengadoresConFoto();
            this.listadoVengadoresConFoto = listado.ListadoCompletoVengadoresConFoto();
        }

        public List<ClsVengadorConFoto> ListadoVengadoresConFoto
        {
            get
            {
                return listadoVengadoresConFoto;
            }
        }

        public List<ClsMision> ListadoMisiones
        {
            get
            {
                return listadoMisiones;
            }
        }

        public ClsVengadorConFoto VengadorSeleccionado
        {
            get
            {
                return vengadorSeleccionado;
            }
            set
            {
                vengadorSeleccionado = value;
                ClsListadoDeMisiones listado = new ClsListadoDeMisiones();
                this.listadoMisiones = listado.ListadoCompletoDeMisiones();
                NotifyPropertyChanged("listadoMisiones");
            }
        }

        public ClsMision MisionSeleccionada
        {
            get
            {
                return misionSeleccionada;
            }
            set
            {
                misionSeleccionada = value;
                //NotifyPropertyChanged("listadoMisiones");
            }
        }
    }
}
