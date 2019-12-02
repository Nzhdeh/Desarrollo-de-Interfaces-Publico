using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1trimestreNzhdehUWP.Modelos
{
    public class ClsSuperheroe
    {
        private int idSuperheroe;
        private string nombreSuperheroe;

        public ClsSuperheroe()
        {
            this.idSuperheroe = 0;
            this.nombreSuperheroe = "no hay";
        }

        public ClsSuperheroe(int idSuperheroe,string nombreSuperheroe)
        {
            this.idSuperheroe = idSuperheroe;
            this.nombreSuperheroe = nombreSuperheroe;
        }

        public int IdSuperheroe { get; set; }
        public String NombreSuperheroe { get; set; }
    }
}
