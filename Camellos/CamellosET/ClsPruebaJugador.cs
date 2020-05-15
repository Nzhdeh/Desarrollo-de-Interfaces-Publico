using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamellosET
{
    public class ClsPruebaJugador
    {
        private int idJugador;
        private int idPrueba;
        private string tiemoJugador;

        #region constructores
        public ClsPruebaJugador()
        {
            this.idJugador = 0;
            this.idPrueba = 0;
            this.tiemoJugador = "";
        }

        public ClsPruebaJugador(int idJugador, int idPrueba, string tiemoJugador)
        {
            this.idJugador = idJugador;
            this.idPrueba = idPrueba;
            this.tiemoJugador = tiemoJugador;
        }
        #endregion

        #region propiedades publicas
        public int IdJugador
        {
            get
            {
                return this.idJugador;
            }
            set
            {
                this.idJugador = value;
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

        public string TiemoJugador
        {
            get
            {
                return this.tiemoJugador;
            }
            set
            {
                this.tiemoJugador = value;
            }
        }
        #endregion
    }
}
