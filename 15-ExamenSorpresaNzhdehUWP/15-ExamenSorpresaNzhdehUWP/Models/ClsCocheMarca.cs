using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_ExamenSorpresaNzhdehUWP.Models
{
    public class ClsCocheMarca
    {
        //las privadas en minuscula y las publicas en mayuscula
        private int id;
        private string marca;

        public ClsCocheMarca()
        {
            this.id = 0;
            this.marca = "";
        }

        public ClsCocheMarca(int id,String marca)
        {
            this.id = id;
            this.marca = marca;
        }

        //propiedades publicas
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public String Marca
        {
            get
            {
                return marca;
            }
            set
            {
                marca = value;
            }
        }
    }
}
