using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertarPruebasYPalabrasCamellosET
{
    public class ClsPalabras
    {
        private int idPalabra;
	    private string palabra;
	    private int dificultad;

        #region constructores
        public ClsPalabras()
        {
            this.idPalabra = 0;
            this.palabra = "";
            this.dificultad = 0;
        }

        public ClsPalabras(int idPalabra, string palabra, int dificultad)
        {
            this.idPalabra = idPalabra;
            this.palabra = palabra;
            this.dificultad = dificultad;
        }

        public ClsPalabras(string palabra, int dificultad)
        {
            this.palabra = palabra;
            this.dificultad = dificultad;
        }

        public ClsPalabras(ClsPalabras pal)
        {
            this.idPalabra = pal.idPalabra;
            this.palabra = pal.palabra;
            this.dificultad = pal.dificultad;
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

        public string Palabra
        {
            get
            {
                return this.palabra;
            }
            set
            {
                this.palabra = value;
            }
        }

        public int Dificultad
        {
            get
            {
                return this.dificultad;
            }
            set
            {
                this.dificultad = value;
            }
        }
        #endregion
    }
}
