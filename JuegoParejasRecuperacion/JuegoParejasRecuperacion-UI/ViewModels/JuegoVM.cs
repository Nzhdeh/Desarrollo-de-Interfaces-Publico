using JuegoParejasRecuperacion_ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoParejasRecuperacion_UI.ViewModels
{
    public class JuegoVM
    {
        private List<ClsCarta> listadoCartasAleatorias;
        private ClsCarta cartaSeleccionada1;
        private ClsCarta cartaSeleccionada2;
        private DelegateCommand volverMenuPrincipal;
        private string temporizador;

        public List<ClsCarta> ListadoCartasAleatorias
        {
            get { return this.listadoCartasAleatorias; }
            set { this.listadoCartasAleatorias = value; }
        }

        public ClsCarta CartaSeleccionada1
        {
            get { return this.cartaSeleccionada1; }
            set { this.cartaSeleccionada1 = value; }
        }

        public ClsCarta CartaSeleccionada2
        {
            get { return this.cartaSeleccionada2; }
            set { this.cartaSeleccionada2 = value; }
        }

        public DelegateCommand VolverMenuPrincipal
        {
            get { return this.volverMenuPrincipal; }
            set { this.volverMenuPrincipal = value; }
        }

        public string Temporizador
        {
            get { return this.temporizador; }
            set { this.temporizador = value; }
        }
    }
}
