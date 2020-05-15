using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamellosET
{
    public class ClsParaListadoProgresos
    {
        private int prueba;//es para saber la prueba
        private int numeroPalabras;
        private string tiempoMaximo;
        private string tiempoJugador;

        public ClsParaListadoProgresos()
        {
            this.prueba = 0;
            this.numeroPalabras = 0;
            this.tiempoMaximo = "";
            this.tiempoJugador = "";
        }

        public ClsParaListadoProgresos(int prueba,int numeroPalabras, string tiempoMaximo, string tiempoJugador)
        {
            this.prueba = prueba;
            this.numeroPalabras = numeroPalabras;
            this.tiempoMaximo = tiempoMaximo;
            this.tiempoJugador = tiempoJugador;
        }

        public int Prueba
        {
            get
            {
                return this.prueba;
            }
            set
            {
                this.prueba = value;
            }
        }

        public int NumeroPalabras
        {
            get
            {
                return this.numeroPalabras;
            }
            set
            {
                this.numeroPalabras = value;
            }
        }

        public string TiempoMaximo
        {
            get
            {
                return this.tiempoMaximo;
            }
            set
            {
                this.tiempoMaximo = value;
            }
        }

        public string TiempoJugador
        {
            get
            {
                return this.tiempoJugador;
            }
            set
            {
                this.tiempoJugador = value;
            }
        }
    }
}
