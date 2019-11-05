using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _16_BuscaminasUWP.Models
{
    public class ClsCasilla : INotifyPropertyChanged
    {
        private bool esBomba;
        private string rutaIcono;
        private bool yaPulsada;

        public ClsCasilla()
        {
            this.esBomba = false;
            this.rutaIcono = "ms-appx://_16_BuscaminasUWP/Assets/Imagenes/presionar.png";
            this.yaPulsada = false;
        }

        public bool EsBomba
        {
            get
            {
                return esBomba;
            }
            set
            {
                esBomba = value;
            }
        }

        public bool YaPulsada
        {
            get
            {
                return yaPulsada;
            }
            set
            {
                yaPulsada = value;
                NotificarCambioDePropiedad("RutaIcono");
            }
        }

        public String RutaIcono
        {
            get
            {
                return rutaIcono;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// sirve para asignar una imagen a la casilla pulsada
        /// </summary>
        public void GirarCarta()
        {
            if (YaPulsada == true)
            {
                if (EsBomba == true)
                {
                    rutaIcono = "ms-appx://_16_BuscaminasUWP/Assets/Imagenes/bomba.png";
                }
                else
                {
                    rutaIcono = "ms-appx://_16_BuscaminasUWP/Assets/Imagenes/salvado.png";
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void NotificarCambioDePropiedad([CallerMemberName] string nombrePropiedad = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }
    }
}
