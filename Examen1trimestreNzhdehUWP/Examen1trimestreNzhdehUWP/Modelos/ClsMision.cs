using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1trimestreNzhdehUWP.Modelos
{
    public class ClsMision: ClsNotificarCambio
    {
        private int idMision;
        private string tituloMision;
        private string descripcionMision;
        private bool reservada;
        private int idSuperheroe;
        private string observaciones;

        public ClsMision()
        {
            this.idMision=0;
            this.tituloMision="no hay";
            this.descripcionMision = "no hay";
            this.reservada=false;
            this.idSuperheroe=0;
            this.observaciones = "no hay";
        }

        public ClsMision(int idMision,string tituloMision,string descripcionMision,bool reservada,int idSuperheroe,string observaciones)
        {
            this.idMision = idMision;
            this.tituloMision = tituloMision;
            this.descripcionMision = descripcionMision;
            this.reservada = reservada;
            this.idSuperheroe = idSuperheroe;
            this.observaciones = observaciones;
        }
        public int IdMision { get; set; }
        public String TituloMision { get; set; }
        public String DescripcionMision { get; set; }
        public bool Reservada
        {
            get
            {
                return reservada;
            }
            set
            {
                reservada = value;
                NotifyPropertyChanged("reservada");
            }
        }
        public int IdSuperheroe { get; set; }
        public String Observaciones
        {
            get
            {
                return observaciones;
            }
            set
            {
                observaciones = value;
                NotifyPropertyChanged("observaciones");
            }
        }

    }
}
