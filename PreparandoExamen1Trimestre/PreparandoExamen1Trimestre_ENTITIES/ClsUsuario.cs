using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreparandoExamen1Trimestre_ENTITIES
{
    public class ClsUsuario
    {
        public ClsUsuario()
        {
            this.IdUsuario = 0;
            this.Saldo = 0.0;
            this.Correo = "aabb@gmail.com";
            this.Contrasenia = "1234";
            this.IsAdmin = true;
        }

        public ClsUsuario(double saldo, string correo,string contrasenia,bool isAdmin)
        {
            this.Saldo = saldo;
            this.Correo = correo;
            this.Contrasenia = contrasenia;
            this.IsAdmin = isAdmin;
        }

        public int IdUsuario { get; set; }
        public double Saldo { get; set; }
        public string Correo { get; set; }
        public string Contrasenia { get; set; }
        public bool IsAdmin { get; set; }

        //la imagen se asigna en  el set del idUsuario
        //public Uri foto { get; set; }
        //public void asignarImagen()
        //{
        //    this.foto = new Uri("ms-appx:///Assets/Imagenes/Casas/" + idUsuario + ".png");
        //}
    }
}
