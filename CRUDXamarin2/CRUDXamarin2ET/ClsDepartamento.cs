using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDXamarin2ET
{
    public class ClsDepartamento
    {
        public ClsDepartamento()
        {
            this.IdDepartamentoa = 0;
            this.NombreDepartamento = "No nombre";
        }

        public int IdDepartamentoa { get; set; }
        public String NombreDepartamento { get; set; }
    }
}