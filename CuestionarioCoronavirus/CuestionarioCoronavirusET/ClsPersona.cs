using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuestionarioCoronavirusET
{
    public class ClsPersona: ClsVMBase
    {
        private string dniPersona;
        private string nombrePersona;
        private string apellidosPerson;
        private string telefono;
        private string direccion;
        private bool diagnostico;


        public ClsPersona()
        {
            this.dniPersona = "";
            this.nombrePersona = "";
            this.apellidosPerson = "";
            this.telefono = "";
            this.direccion = "";
            this.diagnostico = false;
        }

        public ClsPersona(string dniPersona, string nombrePersona, string apellidosPerson, string telefono, string direccion, bool diagnostico)
        {
            this.dniPersona = dniPersona;
            this.nombrePersona = nombrePersona;
            this.apellidosPerson = apellidosPerson;
            this.telefono = telefono;
            this.direccion = direccion;
            this.diagnostico = diagnostico;
        }

        public string DniPersona
        {
            get
            {
                return dniPersona;
            }
            set
            {
                dniPersona = value;
            }
        }

        public string NombrePersona
        {
            get
            {
                return nombrePersona;
            }
            set
            {
                nombrePersona = value;
            }
        }

        public string ApellidosPerson
        {
            get
            {
                return apellidosPerson;
            }
            set
            {
                apellidosPerson = value;
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }
            set
            {
                telefono = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }
            set
            {
                direccion = value;
            }
        }

        public bool Diagnostico
        {
            get
            {
                return diagnostico;
            }
            set
            {
                diagnostico = value;
            }
        }
    }
}
