using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalesSaturadosET
{
    public class ClsMedico
    {
        private string codigoMedico;
        private string nombreMedico;
        private string apellidosMedico;

        public ClsMedico()
        {
            this.codigoMedico = "";
            this.nombreMedico = "";
            this.apellidosMedico = "";
        }

        public ClsMedico(string codigoMedico, string nombreMedico, string apellidosMedico)
        {
            this.codigoMedico = codigoMedico;
            this.nombreMedico = nombreMedico;
            this.apellidosMedico = apellidosMedico;
        }

        public string CodigoMedico
        {
            get
            {
                return this.codigoMedico;
            }
            set
            {
                this.codigoMedico = value;
            }
        }

        public string NombreMedico
        {
            get
            {
                return this.nombreMedico;
            }
            set
            {
                this.nombreMedico = value;
            }
        }

        public string ApellidosMedico
        {
            get
            {
                return this.apellidosMedico;
            }
            set
            {
                this.apellidosMedico = value;
            }
        }
    }
}
