using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_BuscaminasUWP.Models
{
    public class ClsCasilla
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
            }
        }

        public String RutaIcono
        {
            get
            {
                return rutaIcono;
            }
        }
    }
}
