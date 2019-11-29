using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _19_CRUDPersonas_Entities
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

        [Required]//esto es para que te lo pida si o si
        public int IdPersona { get; set; }
        public String NombrePersona { get; set; }
        public String ApellidosPersona { get; set; }
        public DateTime FechaNacimientoPersona { get; set; }
        public String TelefonoPersona { get; set; }
        public List<Byte> FotoPersona { get; set; }
        public int IDDEpartamento { get; set; }
    }
}