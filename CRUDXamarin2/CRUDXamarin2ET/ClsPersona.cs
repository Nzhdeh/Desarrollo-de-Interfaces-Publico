using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDXamarin2ET
{
    public class ClsPersona
    {
        public ClsPersona()
        {
            this.IdPersona = 0;
            this.NombrePersona = "No nombre";
            this.ApellidosPersona = "No apellidos";
            this.FechaNacimientoPersona = new DateTime();
            this.TelefonoPersona = "6656555444";
            this.FotoPersona = new List<byte>();
            this.IDDEpartamento = 0;
        }

     
        public int IdPersona { get; set; }
        public String NombrePersona { get; set; }
        public String ApellidosPersona { get; set; }
        public DateTime FechaNacimientoPersona { get; set; }
        public String TelefonoPersona { get; set; }
        public List<Byte> FotoPersona { get; set; }
        public int IDDEpartamento { get; set; }
    }
}