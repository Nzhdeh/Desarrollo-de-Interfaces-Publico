using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClienteUWP.Models
{
    public class ClsMensage
    {
        public string Nombre { get; set; }
        public string Mensage { get; set; }

        public ClsMensage()
        {
            Nombre = "nada";
            Mensage = "nada";
        }

        public ClsMensage(String nombre,String mensage)
        {
            Nombre = nombre;
            Mensage = mensage;
        }
    }
}
