using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertarPruebasYPalabrasCamellosET
{
    public class ClsPruebaPalabra
    {
        private int idPalabra;
        private int idPrueba;

        #region constructores
        public ClsPruebaPalabra()
        {
            this.idPalabra = 0;
            this.idPrueba = 0;
        }
        public ClsPruebaPalabra(int idPalabra, int idPrueba)
        {
            this.idPalabra = idPalabra;
            this.idPrueba = idPrueba;
        }
        #endregion

        #region propiedades publicas
        public int IdPalabra
        {
            get
            {
                return this.idPalabra;
            }
            set
            {
                this.idPalabra = value;
            }
        }

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
        #endregion
    }
}
