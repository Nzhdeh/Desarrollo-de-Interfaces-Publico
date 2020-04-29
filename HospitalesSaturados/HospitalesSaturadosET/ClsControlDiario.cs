using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalesSaturadosET
{
    public  class ClsControlDiario
    {
		private string codigoMedico;
		private string fecha;
		private string primeraSesion;
		private string segundaSesion;
		private string terceraSesion;
		private string cuartaSesion;

		public ClsControlDiario()
		{
			this.codigoMedico = " ";
			this.fecha = " ";
			this.primeraSesion = "  ";
			this.segundaSesion = " ";
			this.terceraSesion = " ";
			this.cuartaSesion = " ";

		}
		public ClsControlDiario(string codigoMedico, string fecha, string primeraSesion, string segundaSesion, string terceraSesion, string cuartaSesion)
		{
			this.codigoMedico = codigoMedico;
			this.fecha = fecha;
			this.primeraSesion = primeraSesion;
			this.segundaSesion = segundaSesion;
			this.terceraSesion = terceraSesion;
			this.cuartaSesion = cuartaSesion;
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

		public string Fecha
		{
			get
			{
				return this.fecha;
			}
			set
			{
				this.fecha = value;
			}
		}

		public string PrimeraSesion
		{
			get
			{
				return this.primeraSesion;
			}
			set
			{
				this.primeraSesion = value;
			}
		}

		public string SegundaSesion
		{
			get
			{
				return this.segundaSesion;
			}
			set
			{
				this.segundaSesion = value;
			}
		}
		
		public string TerceraSesion
		{
			get
			{
				return this.terceraSesion;
			}
			set
			{
				this.terceraSesion = value;
			}
		}
		
		public string CuartaSesion
		{
			get
			{
				return this.cuartaSesion;
			}
			set
			{
				this.cuartaSesion = value;
			}
		}
	}
}
