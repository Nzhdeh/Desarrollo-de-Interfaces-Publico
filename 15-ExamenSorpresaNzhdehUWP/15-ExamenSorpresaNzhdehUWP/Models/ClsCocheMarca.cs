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
            this.id = 1;
            this.marca = "Ford";
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
                //OnPropertyChanged("Seleccionado");//nombre de la propiedad publica
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
                //OnPropertyChanged("Seleccionado");//nombre de la propiedad publica
            }
        }
    }
}
