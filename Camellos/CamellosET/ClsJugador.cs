using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamellosET
{
    public class ClsJugador
    {
        private int idJugador;
	    private string nick;
        private string contraseña;

        #region constructores
        public ClsJugador()
        {
            this.idJugador = 0;
            this.nick = "";
            this.contraseña = "";
        }

        public ClsJugador(int idJugador, string nick, string contraseña)
        {
            this.idJugador = idJugador;
            this.nick = nick;
            this.contraseña = contraseña;
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

        public string Nick
        {
            get
            {
                return this.nick;
            }
            set
            {
                this.nick = value;
            }
        }

        public string Contraseña
        {
            get
            {
                return this.contraseña;
            }
            set
            {
                this.contraseña = value;
            }
        }
        #endregion
    }
}
