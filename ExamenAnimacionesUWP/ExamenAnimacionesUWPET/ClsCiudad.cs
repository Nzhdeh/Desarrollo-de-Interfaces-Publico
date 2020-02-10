using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenAnimacionesUWPET
{
    public class ClsCiudad : ClsVMBase
    {
        private int idCiudad;
        private string nombreCiudad;

        public ClsCiudad()
        {
            this.idCiudad = 0;
            this.nombreCiudad = "default";
        }

        public ClsCiudad(int idCiudad, string nombreCiudad)
        {
            this.idCiudad = idCiudad;
            this.nombreCiudad = nombreCiudad;
        }

        public int IdCiudad
        {
            get
            {
                return idCiudad;
            }
            set
            {
                idCiudad = value;
            }
        }

        public string NombreCiudad
        {
            get
            {
                return nombreCiudad;
            }
            set
            {
                nombreCiudad = value;
                NotifyPropertyChanged("NombreCiudad");
            }
        }
    }
}
