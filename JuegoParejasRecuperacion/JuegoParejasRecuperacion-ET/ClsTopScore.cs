using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoParejasRecuperacion_ET
{
    public class ClsTopScore
    {
        private int idPersona;
        private string nombrePersona;
        private string tiempo;

        public ClsTopScore()
        {
            this.idPersona = 0;
            this.nombrePersona = "";
            this.tiempo = "";
        }

        public ClsTopScore(int idPersona,string nombrePersona,string tiempo)
        {
            this.idPersona = idPersona;
            this.nombrePersona = nombrePersona;
            this.tiempo = tiempo;
        }

        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }

        public string NombrePersona
        {
            get { return nombrePersona; }
            set { nombrePersona = value; }
        }

        public string Tiempo
        {
            get { return tiempo; }
            set { tiempo = value; }
        }
    }
}
