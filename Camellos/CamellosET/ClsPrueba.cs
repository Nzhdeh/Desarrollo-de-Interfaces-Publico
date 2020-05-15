using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamellosET
{
    public class ClsPrueba
    {
        private int idPrueba;
        private int numeroPalabras;
        private string tiempoMaximo;//puede que ponga otro tipo de dato

        #region constructores
        public ClsPrueba()
        {
            this.idPrueba = 0;
            this.numeroPalabras = 0;
            this.tiempoMaximo = "";
        }

        public ClsPrueba(int idPrueba, int numeroPalabras, string tiempoMaximo)
        {
            this.idPrueba = idPrueba;
            this.numeroPalabras = numeroPalabras;
            this.tiempoMaximo = tiempoMaximo;
        }
        #endregion

        public int IdPrueba
        {
            get
            {
                return this.idPrueba;
            }
            set
            {
                this.idPrueba = value;
            }
        }

        #region propiedades publicas
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
        #endregion
    }
}
