using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuestionarioCoronavirusET
{
    public class ClsRespuesta
    {
        private int idRespuesta;
        private int idPregunta;
        private string respuesta;
        private bool posibleCaso;

        public ClsRespuesta()
        {
            this.idRespuesta = 0;
            this.idPregunta = 0;
            this.respuesta = "respuesta";
            this.posibleCaso = false;
        }

        public ClsRespuesta(int idRespuesta, int idPregunta, string respuesta, bool posibleCaso)
        {
            this.idRespuesta = idRespuesta;
            this.idPregunta = idPregunta;
            this.respuesta = respuesta;
            this.posibleCaso = posibleCaso;
        }

        public ClsRespuesta(int idPregunta, string respuesta, bool posibleCaso)
        {
            this.idPregunta = idPregunta;
            this.respuesta = respuesta;
            this.posibleCaso = posibleCaso;
        }

        public int IdRespuesta
        {
            get
            {
                return idRespuesta;
            }
            set
            {
                idRespuesta = value;
            }
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

        public string Respuesta
        {
            get
            {
                return respuesta;
            }
            set
            {
                respuesta = value;
            }
        }

        public bool PosibleCaso
        {
            get
            {
                return posibleCaso;
            }
            set
            {
                posibleCaso = value;
            }
        }
    }
}
