using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuestionarioCoronavirusET
{
    public class ClsPregunta
    {
        private int idPregunta;
        private string pregunta;

        public ClsPregunta()
        {
            this.idPregunta = 0;
            this.pregunta = "pregunta";

        }

        public ClsPregunta(int idPregunta, string pregunta)
        {
            this.idPregunta = idPregunta;
            this.pregunta = pregunta;
        }

        public ClsPregunta(string pregunta)
        {
            this.pregunta = pregunta;
        }

        public int IdPregunta
        {
            get
            {
                return idPregunta;
            }
            set
            {
                idPregunta = value;
            }
        }

        public string Pregunta
        {
            get
            {
                return pregunta;
            }
            set
            {
                pregunta = value;
            }
        }
    }
}
